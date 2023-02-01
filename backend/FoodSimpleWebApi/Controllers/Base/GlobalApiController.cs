using Microsoft.AspNetCore.Mvc;

namespace FoodSimpleWebApi.Controllers.Base;

[Route("api/[controller]")]
public abstract class GlobalApiController : ControllerBase
{
}