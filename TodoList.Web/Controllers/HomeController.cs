using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoList.Data;

namespace TodoList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context=context;
        }
        

        public IActionResult Index()
        {
            //ToDoController controller = new ToDoController(_context);
            //return View(controller.GetAll());

            return View();



            //return View(_context.ToDos.Include(t=>t.Category).Where(t=>t.IsActive==true).ToList()); 
            //retun view derken içerisine bütün todo'larımı getirmek istiyorum. ToDo'lara include diyoruz, t goes to t.Category diyerek ve böylelikle Category'lerini de getirerek ToList'e çeviriyorum ve view'in içerisine gönderiyorum. yani index sayfasını return ederken return ettiğim view'in içerisine model olarak bir todo listesi gönderiyorum. şimid bunu index sayfasında karşılayabilmem lazım. 
        }

       
    }
}