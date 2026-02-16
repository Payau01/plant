namespace Clgproj.Events
{
    public class FarmerSchemeRejectedEvent : IEvent
    {
        public int ApplicationId { get; }
        public int FarmerId { get; }

        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public FarmerSchemeRejectedEvent(
            int applicationId,
            int farmerId)
        {
            ApplicationId = applicationId;
            FarmerId = farmerId;
        }
    
    }
}
