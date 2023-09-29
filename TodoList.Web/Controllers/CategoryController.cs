using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.Repository.Shared.Abstract;

namespace TodoList.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public IActionResult GetAll()
        {
            
           return Json (_repository.GetAll().ToList());
        }
   
    }
}
