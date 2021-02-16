using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoProject.Models
{
    public class Job 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ToFormat { get; set; }
        public string SourcePath { get; set; }
        public string CompletePath { get; set; }
        public string CreatedAt { get; set; }
        public string Status { get; set; }
        
        [BsonIgnore]
        public IFormFile VideoFile { get; set; }
        
    }
}