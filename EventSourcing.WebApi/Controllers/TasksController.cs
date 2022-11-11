using EventSourcing.Infratructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AggregateRepository _repository;

        public TasksController(AggregateRepository repository)
        {
            _repository = repository;
        }

        public Task<IActionResult> Create(Guid id, )
        {

        }
    }
}
