using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class TestimonialsController : Controller
    {
        //
        // GET: /Testimonials/

        public ActionResult Index()
        {
            Models.TestimonialsVModel model = new Models.TestimonialsVModel();
            model.Testimonials = new List<Models.ContactsVModel>();
            model.Testimonials.Add(new Models.ContactsVModel() { Name = "Ruslan", Subject = "Review 1" });
            model.Testimonials.Add(new Models.ContactsVModel() { Name = "Serg", Subject = "Review 2" });
            model.Testimonials.Add(new Models.ContactsVModel() { Name = "Andrey", Subject = "Review 3" });
            model.Testimonials.Add(new Models.ContactsVModel() { Name = "Oleksandr", Subject = "Review 4" });
            return PartialView(model);
        }

    }
}
