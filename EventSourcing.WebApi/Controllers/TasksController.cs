using EventSourcing.Infratructure.Repository;
using EventSourcing.Core.Aggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Create(Guid id, [FromForm] string title, string createby)
        {
            var aggregate = await _repository.LoadAsync<Core.Aggregate.Task>(id);
            aggregate.Create(id, title, createby);

            return Ok();
        }
    }
}
