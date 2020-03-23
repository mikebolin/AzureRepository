using AzureRepository.Common.Azure.Entity;

namespace AzureRepository.Common.Azure.Entities
{
    public class TrackingRegistryEntity : AzureEntityBase
    {
        public bool HasRegistered { get; set; }
        public string DriverPhone { get; set; }
        public string AssignedTo { get; set; }
        public string ExternalTrackID { get; set; }
        public string DetailsLink { get; set; }
        public string PushStatus { get; set; }
        public string PushMessage { get; set; }
        public string LastAction { get; set; }
    }
}
