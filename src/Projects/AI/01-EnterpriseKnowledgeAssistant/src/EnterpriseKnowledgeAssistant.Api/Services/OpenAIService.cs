using EnterpriseKnowledgeAssistant.Api.Configuration;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace EnterpriseKnowledgeAssistant.Api.Services;

public class OpenAIService : IAIService
{
    private readonly OpenAISettings _settings;

    public OpenAIService(IOptions<OpenAISettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task<string> AskAsync(string question)
    {
        var client = new ChatClient(
            model: _settings.Model,
            apiKey: _settings.ApiKey);

        var response = await client.CompleteChatAsync(question);

        return response.Value.Content[0].Text;
    }
}