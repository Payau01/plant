namespace Clgproj.Events
{
    public class FarmerSchemeApprovedEvent : IEvent
    {
        public int ApplicationId { get; }
        public int FarmerId { get; }

        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public FarmerSchemeApprovedEvent(
            int applicationId,
            int farmerId)
        {
            ApplicationId = applicationId;
            FarmerId = farmerId;
        }
    
    }
}
