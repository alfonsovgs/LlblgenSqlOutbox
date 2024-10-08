﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Persistence.Sql;
using NServiceBus.Transport.SQLServer;
using Shared;

namespace Sender
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "Samples.SqlOutbox.Sender";
            var random = new Random();

            var endpointConfiguration = new EndpointConfiguration("Samples.SqlOutbox.Sender");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.SendFailedMessagesTo("error");

            #region SenderConfiguration

            const string connection = @"Data Source=(localdb)\MSSQLLocalDB;Database=NsbSamplesSqlOutbox;Integrated Security=True;Max Pool Size=100";

            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.ConnectionString(connection);
            transport.DefaultSchema("sender");
            transport.UseSchemaForQueue("error", "dbo");
            transport.UseSchemaForQueue("audit", "dbo");
            transport.UseNativeDelayedDelivery().DisableTimeoutManagerCompatibility();

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.ConnectionBuilder(
                connectionBuilder: () => new SqlConnection(connection));

            var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
            dialect.Schema("sender");
            persistence.TablePrefix("");

            var subscriptions = persistence.SubscriptionSettings();
            subscriptions.DisableCache();

            endpointConfiguration.EnableOutbox();

            #endregion

            SqlHelper.CreateSchema(connection, "sender");
            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press enter to send a message");
            Console.WriteLine("Press any key to exit");

            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }

                var orderSubmitted = new OrderSubmitted
                {
                    OrderId = Guid.NewGuid(),
                    Value = random.Next(100)
                };
                await endpointInstance.Publish(orderSubmitted)
                    .ConfigureAwait(false);
            }

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}