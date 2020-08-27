namespace HealthDataAPI.Models
{
    public class HealthDataDbSettings: IHealthDataDbSettings
    {
        public string PatientsCollectionName { get; set; }
        public string HospitalsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IHealthDataDbSettings
    {
        string PatientsCollectionName { get; set; }
        string HospitalsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
