namespace VideoProject.Models
{
    // MongoDB settings
    public class MDatabaseSettings : IMDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString {get; set; }
        public string DatabaseName { get; set; }
    }
    
    public interface IMDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString {get; set; }
        string DatabaseName { get; set; }
    }
}