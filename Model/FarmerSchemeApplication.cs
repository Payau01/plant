namespace Clgproj.Model
{
    public class FarmerSchemeApplication
    {
        public int Id { get; set; }

        public int SchemeId { get; set; }
        public int FarmerId { get; set; }

        public DateTime AppliedOn { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Pending";
        // Pending | Approved | Rejected
    }
}

