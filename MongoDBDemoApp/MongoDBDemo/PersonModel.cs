﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBDemo
{
    public class PersonModel
    {
        [BsonId] // _id
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel  PrimaryAddress { get; set; }
        [BsonElement("dob")]
        public DateTime DateOfBirth { get; set; }
    }
}
