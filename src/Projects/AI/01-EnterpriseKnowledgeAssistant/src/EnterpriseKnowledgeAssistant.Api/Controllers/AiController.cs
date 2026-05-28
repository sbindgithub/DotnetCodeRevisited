using EnterpriseKnowledgeAssistant.Api.Models;
using EnterpriseKnowledgeAssistant.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace EnterpriseKnowledgeAssistant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AIController : ControllerBase
{
    private readonly IAIService _aiService;

    public AIController(IAIService aiService)
    {
        _aiService = aiService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] AskRequest request)
    {
        var result = await _aiService.AskAsync(request.Questions);

        return Ok(new AskResponse
        {
            Answer = result
        });
    }
}