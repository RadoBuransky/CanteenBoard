using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using CanteenBoard.Entities.Menu;
using CanteenBoard.Entities;

namespace CanteenBoard.Repositories.Impl
{
    public class GenericRepository : IRepository
    {
        private const string _foodCollection = "Food";

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
            GetDatabase()[GetCollectionName(entity)].Save(entity);
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
        private static string GetCollectionName(object entity)
        {
            if (entity is Food)
            {
                return _foodCollection;
            }

            throw new CanteenBoardException("Collection not defined!");
        }
    }
}
