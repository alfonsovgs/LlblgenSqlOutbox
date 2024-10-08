﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Persistence.Sql;
using NServiceBus.Transport.SQLServer;
using Shared;

namespace Receiver
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "Samples.SQLOutboxEF.Receiver";

            const string connection = @"Data Source=(localdb)\MSSQLLocalDB;Database=NsbSamplesSqlOutbox;Integrated Security=True;Max Pool Size=100";

            var endpointConfiguration = new EndpointConfiguration("Samples.SqlOutbox.Receiver");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.SendFailedMessagesTo("error");

            #region ReceiverConfiguration

            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.ConnectionString(connection);
            transport.DefaultSchema("receiver");
            transport.UseSchemaForEndpoint("Samples.SqlOutbox.Sender", "sender");
            transport.UseSchemaForQueue("error", "dbo");
            transport.UseSchemaForQueue("audit", "dbo");
            transport.UseNativeDelayedDelivery().DisableTimeoutManagerCompatibility();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(OrderAccepted).Assembly, "Samples.SqlOutbox.Sender");
            routing.RegisterPublisher(typeof(OrderAccepted).Assembly, "Samples.SqlOutbox.Sender");

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new SqlConnection(connection);
                });
            var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
            dialect.Schema("receiver");
            persistence.TablePrefix("");

            var subscriptions = persistence.SubscriptionSettings();
            subscriptions.DisableCache();

            endpointConfiguration.EnableOutbox();

            #endregion
            SqlHelper.CreateSchema(connection, "receiver");

            SqlHelper.ExecuteSql(connection, File.ReadAllText("Startup.sql"));

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
