using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab02.Pages
{
    public class FeaturesModel : PageModel
    {
        private JsonDataProvider<Testimonial> _testimonialContext;

        public FeaturesModel(JsonDataProvider<Testimonial> testimonialContext)
        {
            _testimonialContext = testimonialContext ?? throw new ArgumentNullException(nameof(testimonialContext));
        }

        public IEnumerable<Testimonial> Testimonials()
        {
            return _testimonialContext.GetData();
        }

        public void OnGet()
        {
        }
    }
}
