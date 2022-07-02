using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseLayer
{
    public class CollaboratorsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string CollaboratorsID { get; set; }

        [ForeignKey("NoteModel")]
        public string NoteID { get; set; }
        public virtual NoteModel NoteModel { get; set; }

        public string emailID { get; set; }
    }
}
