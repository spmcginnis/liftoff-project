using HealthDataAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace HealthDataAPI.Services
{
    public class HospitalService
    {
        private readonly IMongoCollection<Hospitals> _hospitals;

        public HospitalService(IHealthDataDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hospitals = database.GetCollection<Hospitals>(settings.HospitalsCollectionName);
        }

        public List<Hospitals> Get() =>
            _hospitals.Find(hospitals => true).ToList();

        public Hospitals Get(string id) =>
            _hospitals.Find<Hospitals>(hospitals => hospitals.Id == id).FirstOrDefault();

        public Hospitals Create(Hospitals hospitals)
        {
            _hospitals.InsertOne(hospitals);
            return hospitals;
        }

        public void Update(string id, Hospitals hospitalsIn) =>
            _hospitals.ReplaceOne(hospitals => hospitals.Id == id, hospitalsIn);

        public void Remove(Hospitals hospitalsIn) =>
            _hospitals.DeleteOne(hospitals => hospitals.Id == hospitalsIn.Id);

        public void Remove(string id) =>
            _hospitals.DeleteOne(hospitals => hospitals.Id == id);
    }
}
