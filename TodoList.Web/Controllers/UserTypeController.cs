using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.Repository.Shared.Abstract;

namespace TodoList.Web.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly IRepository<UserType> _repository;

        public UserTypeController(IRepository<UserType> repository)
        {
            _repository = repository;
        }
       public IActionResult GetAll()
       {
            return Json(_repository.GetAll().ToList());
       }
    }
}
