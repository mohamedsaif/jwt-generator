using JWT.Generator.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Generator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JWTTokenController : ControllerBase
    {
        private readonly ILogger<JWTTokenController> _logger;

        public JWTTokenController(ILogger<JWTTokenController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetToken/{userId}")]
        [ProducesResponseType(typeof(SecurityToken), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetToken(string userId)
        {
            var token = TokenGenerator.GenerateToken(userId);
            if (token == null)
            {
                return new BadRequestObjectResult("failed to generate token");
            }
            return new OkObjectResult(token);
        }

        [HttpGet("GetTokenValue/{userId}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTokenValue(string userId)
        {
            var token = TokenGenerator.GenerateTokenAsString(userId);
            if (token == null)
            {
                return new BadRequestObjectResult("failed to generate token");
            }
            return new OkObjectResult(token);
        }
    }
}