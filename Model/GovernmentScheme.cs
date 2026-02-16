namespace Clgproj.Model
{
    public class GovernmentScheme
    {
        public int Id { get; set; }

        public string SchemeName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ApplicableCrop { get; set; } = string.Empty;

        public string Season { get; set; } = string.Empty;

        public decimal BenefitAmount { get; set; }

        public string BenefitType { get; set; } = string.Empty;
        // Subsidy | Loan | Insurance | Equipment Support

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public string EligibilityCriteria { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public decimal MaxLandSizeAllowed { get; internal set; }
        public string? State { get; internal set; }
    }
}

