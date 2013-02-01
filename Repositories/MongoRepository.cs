using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Repositories
{
    public abstract class MongoRepository
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <returns></returns>
        protected MongoClient CreateClient()
        {
            return new MongoClient(ConnectionString);
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        protected MongoDatabase Database
        {
            get
            {
                return CreateClient().GetServer().GetDatabase(DatabaseName);
            }
        }
    }
}
