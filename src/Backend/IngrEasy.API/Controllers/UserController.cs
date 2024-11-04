using IngrEasy.Application.UseCases.User.Register;
using IngrEasy.Communication.Requests;
using IngrEasy.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace IngrEasy.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType( typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    
    public async Task<IActionResult> Register(RequestRegisterUserJson request, [FromServices] IRegisterUserUseCase useCase)
    {
        
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);    
    }
    
    
}