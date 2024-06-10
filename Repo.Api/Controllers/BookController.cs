using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Core;
using Repo.Core.Interface;
using Repo.Core.Models;

namespace Repo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetByID")]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.books.FindWithInClode(x => x.Id == 1, new string[1] {"Author"} ));
        }
    }
}
