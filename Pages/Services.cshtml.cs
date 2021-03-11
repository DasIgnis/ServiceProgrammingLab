using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab02.Pages
{
    public class ServicesModel : PageModel
    {
        private JsonDataProvider<Testimonial> _testimonialContext;
        private JsonDataProvider<Service> _serviceContext;

        public ServicesModel(
            JsonDataProvider<Testimonial> testimonialContext,
            JsonDataProvider<Service> serviceContext)
        {
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
