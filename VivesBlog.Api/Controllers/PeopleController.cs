using Microsoft.AspNetCore.Mvc;
using VivesBlog.Model;
using VivesBlog.Model.Dto;
using VivesBlog.Model.ServiceResult;
using VivesBlog.Services;

namespace VivesBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonService _personService;

        public PeopleController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Find()
        {
            var people = _personService.Find();
            
            var dtos = people.Select(p => new PersonDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                NumberOfArticles = p.Articles?.Count ?? 0
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                var errorResult = new GenericServiceResult<PersonDto>
                {
                    Errors = new List<ServiceError>
            {
                new ServiceError
                {
                    Code = "InvalidId",
                    Message = "ID must be greater than 0",
                    Type = ErrorType.Error
                }
            }
                };
                return BadRequest(errorResult);
            }

            var person = _personService.Get(id);
            if (person == null)
            {
                var notFoundResult = new GenericServiceResult<PersonDto>
                {
                    Errors = new List<ServiceError>
            {
                new ServiceError
                {
                    Code = "NotFound",
                    Message = "Person not found",
                    Type = ErrorType.Error
                }
            }
                };
                return NotFound(notFoundResult);
            }

            var dto = new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                NumberOfArticles = person.Articles?.Count ?? 0
            };

            var result = new GenericServiceResult<PersonDto>
            {
                Data = dto
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonDto dto)
        {
            var person = new Person
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            var created = _personService.Create(person);

            var resultDto = new PersonDto
            {
                Id = created.Id,
                FirstName = created.FirstName,
                LastName = created.LastName,
                Email = created.Email,
                NumberOfArticles = 0
            };

            return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PersonDto dto)
        {
            var person = new Person
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            var updated = _personService.Update(id, person);
            if (updated == null)
                return NotFound();

            var resultDto = new PersonDto
            {
                Id = updated.Id,
                FirstName = updated.FirstName,
                LastName = updated.LastName,
                Email = updated.Email,
                NumberOfArticles = updated.Articles?.Count ?? 0
            };

            return Ok(resultDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}