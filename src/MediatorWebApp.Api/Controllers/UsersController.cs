using AutoMapper;
using MediatorWebApp.Core;
using MediatorWebApp.Core.Handlers.Command;
using MediatorWebApp.Core.Handlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(
            IMediator mediator,
            ApplicationDbContext context,
            IMapper mapper)
        {
            (_mediator, _context, _mapper) = (mediator, context, mapper);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserView user)
        {
            var map = _mapper.Map<User>(user);

            await _mediator.Send(new CreateUserCommand() { User = map});

            return Ok(map);
        }
    }
}