namespace PortfolioApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string ProjectLink { get; set; } = string.Empty;
        public string ImagePath { get; set; }   = string.Empty;
    }
}
