using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoList.Data;

namespace TodoList.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
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