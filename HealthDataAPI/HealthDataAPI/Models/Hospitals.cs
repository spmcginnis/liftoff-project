using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthDataAPI.Models
{
    public class Hospitals
    {
        [BsonId] //designates the primary key
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // this could be made as an interface

        //ID=HospitalCode, Name, Location, Staffed Beds, Total Discharges, Patient Days, Gross Patient Revenue ($000), address
        //How do I limit the fields that are exposed to the API?  A: with getters and setters.
        [BsonElement("ID")]
        public string HospitalCode { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [BsonElement("Staffed Beds")]
        public int Beds { get; set; }

        [BsonElement("Total Discharges")]
        public int Discharges { get; set; }

        [BsonElement("Patient Days")]
        public int PatientDays { get; set; }

        [BsonElement("Gross Patient Revenue ($000)")]
        public string Revenue { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

    }
}
