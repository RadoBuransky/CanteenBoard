using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using CanteenBoard.Entities.Menu;
using CanteenBoard.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using System.Diagnostics.Contracts;
using MongoDB.Driver.Builders;
using CanteenBoard.Entities.Boards;
using System.Drawing;

namespace CanteenBoard.Repositories.Impl
{
    public class GenericRepository : IRepository
    {
        private const string _foodCollection = "Food";
        private const string _screenTemplateCollection = "ScreenTemplate";
        private const string _customColorsCollection = "CustomColors";

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository" /> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        public GenericRepository(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        protected string DatabaseName { get; private set; }

        /// <summary>
        /// Thread-safe Mongo client.
        /// </summary>
        private static MongoClient _mongoClient;

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(object entity)
        {
            Contract.Requires(entity != null);

            GetCollection(entity).Save(entity);
        }

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        /// Queryable interface for further usage in LINQ expression.
        /// </returns>
        public IQueryable<T> Find<T>()
        {
            return GetCollection(typeof(T)).AsQueryable<T>();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectId">The object id.</param>
        public void Delete<T>(string objectId)
        {
            Contract.Requires(!string.IsNullOrEmpty(objectId));

            GetCollection(typeof(T)).Remove(Query.EQ("_id", objectId));
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <returns></returns>
        protected MongoClient GetMongoClient()
        {
            if (_mongoClient == null)
            {
                _mongoClient = new MongoClient(ConnectionString);
                CreateClassMaps();
            }

            return _mongoClient;
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <returns></returns>
        protected MongoDatabase GetDatabase()
        {
            return GetMongoClient().GetServer().GetDatabase(DatabaseName);
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private MongoCollection<BsonDocument> GetCollection(object entity)
        {
            return GetCollection(entity.GetType());
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        private MongoCollection<BsonDocument> GetCollection(Type type)
        {
            return GetDatabase()[GetCollectionName(type)];
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private static string GetCollectionName(Type type)
        {
            if (type.IsAssignableFrom(typeof(Food)))
            {
                return _foodCollection;
            }
            if (type.IsAssignableFrom(typeof(ScreenTemplate)))
            {
                return _screenTemplateCollection;
            }
            if (type.IsAssignableFrom(typeof(CustomColor)))
            {
                return _customColorsCollection;
            }

            throw new CanteenBoardException("Collection not defined!");
        }

        /// <summary>
        /// Creates the class maps.
        /// </summary>
        private static void CreateClassMaps()
        {
            BsonClassMap.RegisterClassMap<Food>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.Title));
            });
            BsonClassMap.RegisterClassMap<ScreenTemplate>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.ScreenDeviceName));
            });
            BsonClassMap.RegisterClassMap<CustomColor>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.Key));
            });
        }
    }
}
