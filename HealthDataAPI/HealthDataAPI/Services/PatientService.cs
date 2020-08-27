using HealthDataAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace HealthDataAPI.Services
{
    public class PatientService
    {
        private readonly IMongoCollection<Patients> _patients;

        public PatientService(IHealthDataDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _patients = database.GetCollection<Patients>(settings.PatientsCollectionName);
        }

        public List<Patients> Get() =>
            _patients.Find(patients => true).ToList();

        public Patients Get(string id) =>
            _patients.Find<Patients>(patients => patients.Id == id).FirstOrDefault();

        public Patients Create(Patients patients)
        {
            _patients.InsertOne(patients);
            return patients;
        }

        public void Update(string id, Patients patientsIn) =>
            _patients.ReplaceOne(patients => patients.Id == id, patientsIn);

        public void Remove(Patients patientsIn) =>
            _patients.DeleteOne(patients => patients.Id == patientsIn.Id);

        public void Remove(string id) =>
            _patients.DeleteOne(patients => patients.Id == id);
    }
}
