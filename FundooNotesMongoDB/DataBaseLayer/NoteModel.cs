using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseLayer
{
    public class NoteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string NoteID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public bool IsPin { get; set; }
        public bool IsArchive { get; set; }
        public bool IsRemainder { get; set; }
        public bool IsTrash { get; set; }

        public DateTime Remainder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifedDate { get; set; }
        
        [ForeignKey("UserModel")]
        public string userId { get; set; }
        public virtual UserModel UserModel { get; set; }
    }
}
