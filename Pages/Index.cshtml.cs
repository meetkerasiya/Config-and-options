using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly HomePageConfiguration _homePageConfiguration;

        public string greeting = "Good Evening!";
        public string title = "null";

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IOptions<HomePageConfiguration> option)
        {
            _logger = logger;
            _configuration = configuration;
            try
            {
                _homePageConfiguration = option.Value;
            }
            catch (OptionsValidationException ex)
            {
                foreach (var failure in ex.Failures)
                {
                    _logger.LogError(failure);
                }
            }
        }

        public void OnGet()
        {
            //var feature = new Feature();
            //_configuration.Bind("Features:HomePage", feature);

            if(_homePageConfiguration.EnableGreeting)
            {
                greeting = "Good Morning!!!";
                title = _homePageConfiguration.ForeCaseSectionTitle;
            }

            //var homePageFeature = _configuration.GetSection("Features:HomePage");
            //if (homePageFeature.GetValue<bool>("EnableGreeting"))
            //{
            //    greeting = "Good morning!";
            //    title = homePageFeature["ForeCaseSectionTitle"];
            //}
            //if (_configuration.GetValue<bool>("Features:HomePage:EnableGreeting"))
            //{
            //    greeting = "Good afternoon!";
            //}
        }
    }

    class Feature
    {
        public bool EnableGreeting { get; set; }
        public string ForeCaseSectionTitle { get; set; }
    }
}