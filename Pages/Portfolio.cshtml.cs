using System;
using System.Collections.Generic;
using Lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab02.Pages
{
    public class PortfolioModel : PageModel
    {
        private JsonDataProvider<PortfolioItem> _portfolioContext;
        private JsonDataProvider<Testimonial> _testimonialContext;
        private JsonDataProvider<Service> _serviceContext;
        public PortfolioModel(
            JsonDataProvider<PortfolioItem> portfolioContext,
            JsonDataProvider<Testimonial> testimonialContext,
            JsonDataProvider<Service> serviceContext)
        {
            _portfolioContext = portfolioContext ?? throw new ArgumentNullException(nameof(portfolioContext));
            _testimonialContext = testimonialContext ?? throw new ArgumentNullException(nameof(testimonialContext));
            _serviceContext = serviceContext ?? throw new ArgumentNullException(nameof(serviceContext));
        }

        public IEnumerable<PortfolioItem> Portfolios()
        {
            return _portfolioContext.GetData();
        }

        public IEnumerable<Testimonial> Testimonials()
        {
            return _testimonialContext.GetData();
        }

        public IEnumerable<Service> Services()
        {
            return _serviceContext.GetData();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
