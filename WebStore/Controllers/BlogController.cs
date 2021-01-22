using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers {

    public class BlogController : Controller {

        public IActionResult List() => View();

        public IActionResult Single() => View();

    }
}
