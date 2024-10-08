﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NsbSamplesSqlOutbox.HelperClasses;
using NsbSamplesSqlOutbox.FactoryClasses;
using NsbSamplesSqlOutbox.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NsbSamplesSqlOutbox.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'SubscriptionData'.<br/><br/></summary>
	[Serializable]
	public partial class SubscriptionDataEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
	
	{
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		private static SubscriptionDataEntityStaticMetaData _staticMetaData = new SubscriptionDataEntityStaticMetaData();
		private static SubscriptionDataRelations _relationsFactory = new SubscriptionDataRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class SubscriptionDataEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public SubscriptionDataEntityStaticMetaData()
			{
				SetEntityCoreInfo("SubscriptionDataEntity", InheritanceHierarchyType.None, false, (int)NsbSamplesSqlOutbox.EntityType.SubscriptionDataEntity, typeof(SubscriptionDataEntity), typeof(SubscriptionDataEntityFactory), false);
			}
		}

		/// <summary>Static ctor</summary>
		static SubscriptionDataEntity()
		{
		}

		/// <summary> CTor</summary>
		public SubscriptionDataEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SubscriptionDataEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SubscriptionDataEntity</param>
		public SubscriptionDataEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="messageType">PK value for SubscriptionData which data should be fetched into this SubscriptionData object</param>
		/// <param name="subscriber">PK value for SubscriptionData which data should be fetched into this SubscriptionData object</param>
		public SubscriptionDataEntity(System.String messageType, System.String subscriber) : this(messageType, subscriber, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="messageType">PK value for SubscriptionData which data should be fetched into this SubscriptionData object</param>
		/// <param name="subscriber">PK value for SubscriptionData which data should be fetched into this SubscriptionData object</param>
		/// <param name="validator">The custom validator object for this SubscriptionDataEntity</param>
		public SubscriptionDataEntity(System.String messageType, System.String subscriber, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.MessageType = messageType;
			this.Subscriber = subscriber;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SubscriptionDataEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this SubscriptionDataEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END


			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static SubscriptionDataRelations Relations { get { return _relationsFactory; } }

		/// <summary>The Endpoint property of the Entity SubscriptionData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SubscriptionData"."Endpoint".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Endpoint
		{
			get { return (System.String)GetValue((int)SubscriptionDataFieldIndex.Endpoint, true); }
			set	{ SetValue((int)SubscriptionDataFieldIndex.Endpoint, value); }
		}

		/// <summary>The MessageType property of the Entity SubscriptionData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SubscriptionData"."MessageType".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.String MessageType
		{
			get { return (System.String)GetValue((int)SubscriptionDataFieldIndex.MessageType, true); }
			set	{ SetValue((int)SubscriptionDataFieldIndex.MessageType, value); }
		}

		/// <summary>The PersistenceVersion property of the Entity SubscriptionData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SubscriptionData"."PersistenceVersion".<br/>Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 23.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PersistenceVersion
		{
			get { return (System.String)GetValue((int)SubscriptionDataFieldIndex.PersistenceVersion, true); }
			set	{ SetValue((int)SubscriptionDataFieldIndex.PersistenceVersion, value); }
		}

		/// <summary>The Subscriber property of the Entity SubscriptionData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SubscriptionData"."Subscriber".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.String Subscriber
		{
			get { return (System.String)GetValue((int)SubscriptionDataFieldIndex.Subscriber, true); }
			set	{ SetValue((int)SubscriptionDataFieldIndex.Subscriber, value); }
		}
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END


	}
}

namespace NsbSamplesSqlOutbox
{
	public enum SubscriptionDataFieldIndex
	{
		///<summary>Endpoint. </summary>
		Endpoint,
		///<summary>MessageType. </summary>
		MessageType,
		///<summary>PersistenceVersion. </summary>
		PersistenceVersion,
		///<summary>Subscriber. </summary>
		Subscriber,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace NsbSamplesSqlOutbox.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: SubscriptionData. </summary>
	public partial class SubscriptionDataRelations: RelationFactory
	{

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticSubscriptionDataRelations
	{

		/// <summary>CTor</summary>
		static StaticSubscriptionDataRelations() { }
	}
}
