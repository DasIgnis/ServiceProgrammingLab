using Lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private JsonDataProvider<Testimonial> _testimonialContext;
        private JsonDataProvider<Service> _serviceContext;

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonDataProvider<Testimonial> testimonialContext,
            JsonDataProvider<Service> serviceContext)
        {
            _logger = logger;
            _testimonialContext = testimonialContext ?? throw new ArgumentNullException(nameof(testimonialContext));
            _serviceContext = serviceContext ?? throw new ArgumentNullException(nameof(serviceContext));
        }

        public IEnumerable<Testimonial> Testimonials()
        {
            return _testimonialContext.GetData();
        }

        public IEnumerable<Service> Services()
        {
            return _serviceContext.GetData();
        }

        public void OnGet()
        {

        }
    }
}
