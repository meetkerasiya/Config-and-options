using System.ComponentModel.DataAnnotations;

namespace Demo
{
    public class HomePageConfiguration
    {
        public bool EnableGreeting { get; set; }
        [Required]
        public string ForeCaseSectionTitle { get; set; } =string.Empty;
    }
}
