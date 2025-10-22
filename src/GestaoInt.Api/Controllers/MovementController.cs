using GestaoInt.Application.UseCase.Movements.Register;
using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInt.Api.Controllers
{
    [ApiController]
    public class MovementController : ControllerBase
    {
        [HttpPost]
        [Route("movement-register")]
        [ProducesResponseType(typeof(ResponseRegisterdMovementJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterMovementUseCase useCase, [FromBody] RequestMovementJson request)
        {
            var response = await useCase.Execute(request);

            Console.WriteLine(response);

            return Created(string.Empty, response);
        } 
    }
}
