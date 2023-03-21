using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Milestone_4_Mongo.Models
{   
    //model used to access the data from database
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        public string category { get; set; }

        public string image { get; set; }

        public int price { get; set; }

        public int countInStock { get; set; }


        public string brand { get; set; }

        public int rating { get; set; }

        public int reviews { get; set; }

        public string description { get; set; }
    }


}
