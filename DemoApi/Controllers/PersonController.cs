using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("persons")]
        [HttpGet]
        public async Task<IReadOnlyCollection<PersonModel>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        [Route("person/{id}")]
        [HttpGet]
        public async Task<PersonModel> Get(int id) => 
            await _mediator.Send(new GetPersonByIdQuery(id));

        [Route("person")]
        [HttpPost]
        public async Task<PersonModel> Create([FromBody] PersonModel personModel)
        {
            return await _mediator.Send(
                new CreatePersonCommand(personModel.FirstName, personModel.LastName));
        }
    }
}
