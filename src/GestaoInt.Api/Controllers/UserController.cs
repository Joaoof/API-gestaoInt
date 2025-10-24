using GestaoInt.Application.UseCase.Movements.Register;
using GestaoInt.Application.UseCase.Users.Register;
using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;
using GestaoInt.Domain.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInt.Api.Controllers
{
    [ApiController]
    public class UserController: ControllerBase
    {
        [HttpPost]
        [Route("user-created")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestUserJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
