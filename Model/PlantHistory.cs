namespace Clgproj.Model
{
    public class plantHistory
    {
        public int Id { get; set; }
        public int PlantId { get; set; }

        public string? EventType { get; set; }   // e.g. "Watered", "Fertilized"
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
    }

}
    