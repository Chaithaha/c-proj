namespace GameFinder.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public double Rating { get; set; }
    }
}