using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TodoList.Data;
using TodoList.Models;
using TodoList.Repository.Abstract;
using TodoList.Repository.Shared.Abstract;

namespace TodoList.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repository;
        private readonly IRepository<Category> _categoryRepository;
       

        public ToDoController(IToDoRepository repository, IRepository<Category> categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //_context.ToDos.Remove(_context.ToDos.Find(id));
            //_context.SaveChanges();
            _repository.DeleteById(id);
            _repository.Save();
            return Ok();

        }

        public IActionResult GetAll()
        {
            //return Json(_context.ToDos.Include(t => t.Category).Where(t => t.IsActive == true && t.UserId == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))).ToList());  //listeleme oldugu zaman foreach

            return Json(_repository.GetAll(t=>t.IsActive ==true && t.UserId==int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))).Include(t=>t.Category).ToList());
        }


        [HttpPost] //YAPILDI BUTONU
        public IActionResult SetIsActive(int id)
        {
            //ToDo todo =_context.ToDos.Find(id);
            //todo.IsActive = false;
            //_context.ToDos.Update(todo);
            //_context.SaveChanges();
            //return RedirectToAction("Index","Home");

            //ToDo todo =_repository.GetById(id);
            //todo.IsActive = false;
            //_repository.Update(todo);
            //_repository.Save();
            //BU BİRİNCİ YÖNTEM!!!

            _repository.SetIsActive(id);
            _repository.Save();

            return Ok();

        }

        [HttpPost]
        public IActionResult Add(ToDo todo)
        {
            //todo.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); BU KISAYOLU!!!
            //todo.UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _repository.Add(todo);
            _repository.Save();

            
         
            //return RedirectToAction("Index", "Home");
            return Ok();
        }
    }
}
