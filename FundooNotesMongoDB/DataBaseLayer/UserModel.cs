using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string userId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedDate { get; set; }
        public string emailID { get; set; }
        public string password { get; set; }
        public string Address { get; set; }
    }
}
