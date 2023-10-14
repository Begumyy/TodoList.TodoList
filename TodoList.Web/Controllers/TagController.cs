using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TodoList.Models;
using TodoList.Repository.Shared.Abstract;

namespace TodoList.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();


        }

        public IActionResult GetAll()
        {
            //select Name , COUNT(*) as 'Tag Sayısı' from TagToDo JOIN Tags as t ON t.Id=TagToDo.TagsId group by name
            var result =_unitOfWork.Tags.GetAll().Select(x=> new
            {
                x.Name,
                Count=x.ToDos.Count
            }).ToList();

            //var result = _unitOfWork.Tags.GetAll().Select(x => new
            //{
            //    x.Name,
            //    Count = x.ToDos.Count
            //})Where(a=>a.Count>=3).ToList();

            return Json(result);
        }

        public IActionResult Add(Tag tag)
        {
            _unitOfWork.Tags.Add(tag);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
