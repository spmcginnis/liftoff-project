using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthDataAPI.Models
{
    public class Patients
    {
        [BsonId] //designates the primary key
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // this could be made as an interface

        // GivenName, FamilyName, Street, City, State, Zip, Gender, DOB, LanguageCode, HospitalCode
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Street { get; set; } // could make an address class / interface
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int DOB { get; set; }
        public string Gender { get; set; }
        public string LanguageCode { get; set; }
        public string HospitalCode { get; set; } //Do I want to evaluate the hospital code before passing the data through the API?


    }
}
