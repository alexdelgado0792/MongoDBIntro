using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBDemo
{
    public class NameModel
    {
        [BsonId] // _id
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
