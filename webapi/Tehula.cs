using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace webapi
{
    public class Tehula
    {

        public string _id { get; set; }
        public string account { get; set; }
        public string username { get; set; }
        public string testEnvironment { get; set; }
        public string description { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Tehula other)
                return other._id == _id;
            return false;
        }
    }
}
