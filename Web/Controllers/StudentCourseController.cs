using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class StudentCourseController : BaseController
    {
        public StudentCourseController(IUnitOfWork uow) : base(uow)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetAllStudent()//Master
        {
            if (Helper.AuthRoleId == (int)EnumRole.Admin)
                return Json(await Uow.StudentRepository.GetAll());
            return Json(await Uow.StudentRepository.GetWhere(w => w.UserId == Helper.AuthId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetAllStudentCourse(int studentId)//Detail
        {
            return Json(await Uow.StudentCourseRepository.GetAllStudentCourseByStudentId(studentId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> InsertStudentCourse(StudentCourseViewModel studentCourse)
        {
            int a = 1;
            return Json(await Uow.StudentCourseRepository.InsertStudentCourseAsync(studentCourse.Convert()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteStudentCourse(int id)
        {
            int a = 1;
            return Json(await Uow.StudentCourseRepository.DeleteStudentCourseAsync(id));
        }
    }
}
