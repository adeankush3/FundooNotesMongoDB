using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseLayer
{
    public class LabelModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string LabelId { get; set; }

        [ForeignKey("UserModel")]
        public string userId { get; set; }
        public virtual UserModel UserModel { get; set; }

        [ForeignKey("NoteModel")]
        public string NoteID { get; set; }
        public virtual NoteModel NoteModel { get; set; }

        public string Label { get; set; }
    }
}
