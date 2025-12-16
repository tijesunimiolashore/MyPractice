using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPractice.Data;
using MyPractice.Models;
using MyPractice.Models.Entities;

namespace MyPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPracticeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MyPracticeController(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllMyPractice()
        {
            var myPracs = dbContext.MyPracs.ToList();
            return Ok(myPracs);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAllMyPracticeById(Guid id) {
           var objectOfFind = dbContext.MyPracs.Find(id);

            if (objectOfFind is null) {
                return NotFound();
			}

			return Ok(objectOfFind);
        }

		[HttpPost]
        public IActionResult AddMyPractice(MyPracticeDto myPracticeDto)
        {
            var myPracticeEntity = new MyPrac()
            {
                FirstName = myPracticeDto.FirstName,
                LastName = myPracticeDto.LastName,
                PhoneNumber = myPracticeDto.PhoneNumber,
                Salary = myPracticeDto.Salary,
            };

            dbContext.MyPracs.Add(myPracticeEntity);
            dbContext.SaveChanges();

            return Ok(myPracticeEntity);
        }

        [HttpPost]
		[Route("{id:guid}")]
        public IActionResult UpdateMyPractice(Guid id, MyPracticeDto myPracticeDto)
        {
            var existingEntity = dbContext.MyPracs.Find(id);
            if (existingEntity is null)
            {
                return NotFound();
            }
            existingEntity.FirstName = myPracticeDto.FirstName;
            existingEntity.LastName = myPracticeDto.LastName;
            existingEntity.PhoneNumber = myPracticeDto.PhoneNumber;
            existingEntity.Salary = myPracticeDto.Salary;
            dbContext.SaveChanges();
            return Ok(existingEntity);
		}

        [HttpDelete]
        public IActionResult DeleteMyPractice(Guid id)
        {
            var existingEntity = dbContext.MyPracs.Find(id);
            if (existingEntity is null)
            {
                return NotFound();
            }
            dbContext.MyPracs.Remove(existingEntity);
            dbContext.SaveChanges();
            return Ok(existingEntity);
		}
	}
}
