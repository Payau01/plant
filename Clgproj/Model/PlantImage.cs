namespace Clgproj.Model
{
    public class PlantImage

    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public object? AnalysisResults { get; internal set; }

        internal object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
    

