using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBDemo
{
    public class MongoHelper
    {
        private IMongoDatabase db;

        public MongoHelper(string database)
        {
            //Local server connection.
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        /// <summary>
        /// Insert data into collection
        /// </summary>
        /// <typeparam name="T">Document/Entity/Model Type</typeparam>
        /// <param name="table">Collection</param>
        /// <param name="record">Data to insert</param>
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        /// <summary>
        /// Get all records of a specific collection
        /// </summary>
        /// <typeparam name="T">Document/Entity/Model Type</typeparam>
        /// <param name="table">Collection</param>
        /// <returns>Load all collection</returns>
        public IList<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        /// <summary>
        /// Get specific record from the collection
        /// </summary>
        /// <typeparam name="T">Document/Entity/Model</typeparam>
        /// <param name="table">Collection</param>
        /// <param name="identifier">Document/Entity/Model identifer</param>
        /// <returns>Record</returns>
        public T LoadRecordById<T>(string table, Guid identifier)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id",identifier);

            return collection.Find(filter).First();
        }

        /// <summary>
        /// Insert/Update record as needed
        /// </summary>
        /// <typeparam name="T">Document/Entity/Model Type</typeparam>
        /// <param name="table">Collection</param>
        /// <param name="identifier">Document/Entity/Model identifer</param>
        /// <param name="record">>Data to insert or update</param>
        public void UpsertRecord<T>(string table, Guid identifier, T record)
        {
            var collection = db.GetCollection<T>(table);

            collection.ReplaceOne(new BsonDocument("_id", identifier), record, new UpdateOptions { IsUpsert = true });
        }

        /// <summary>
        /// Delete collection
        /// </summary>
        /// <typeparam name="T">Document/Entity/Model Type</typeparam>
        /// <param name="table">Collection</param>
        /// <param name="identifier">Document/Entity/Model identifer</param>
        public void DeleteRecord<T>(string table, Guid identifier)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", identifier);
            collection.DeleteOne(filter);
        }
    }
}
