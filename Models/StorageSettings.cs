namespace VideoProject.Models
{
    public class StorageSettings : IStorageSettings
    {
        public string PathPrefixSource { get; set; }
        public string PathPrefixDestination { get; set; }
        
    }

    public interface IStorageSettings
    {
        public string PathPrefixSource { get; set; }
        public string PathPrefixDestination { get; set; }

    }
}