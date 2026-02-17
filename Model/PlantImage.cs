namespace Clgproj.Model
{
    public class plantImage

    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public decimal AnalysisResults { get; internal set; }

        internal decimal FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
    

