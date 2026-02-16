namespace Clgproj.Events
{
    public class FarmerSchemeAppliedEvent : IEvent
    {
        public int ApplicationId { get; }
        public int FarmerId { get; }
        public int SchemeId { get; }

        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public FarmerSchemeAppliedEvent(
            int applicationId,
            int farmerId,
            int schemeId)
        {
            ApplicationId = applicationId;
            FarmerId = farmerId;
            SchemeId = schemeId;
        }
    
    }
}
