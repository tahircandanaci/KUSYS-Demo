using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class StudentController : BaseController
    {
        public StudentController(IUnitOfWork uow) : base(uow)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetAllStudent()
        {
            return Json(await Uow.StudentRepository.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> InsertStudent(StudentViewModel student)
        {
            return Json(await Uow.StudentRepository.InsertStudentAsync(student.Convert()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateStudent(StudentViewModel student)
        {
            return Json(await Uow.StudentRepository.UpdateStudentAsync(student.Convert()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteStudent(int id)
        {
            return Json(await Uow.StudentRepository.DeleteStudentAsync(id));
        }
    }
}
