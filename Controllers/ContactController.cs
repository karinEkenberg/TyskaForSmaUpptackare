using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TyskaForSmaUpptackare.Controllers
{
    public class ContactController : Controller
    {
        // GET: ContactController
        public ActionResult Index()
        {
            return View();
        }

    }
}
