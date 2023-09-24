using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CourseController : BaseController
    {
        public CourseController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetAllCourse()
        {
            return Json(await Uow.CourseRepository.GetAll());
        }
    }
}
