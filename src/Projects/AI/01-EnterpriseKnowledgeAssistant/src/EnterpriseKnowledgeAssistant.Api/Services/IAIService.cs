namespace EnterpriseKnowledgeAssistant.Api.Services;

public interface IAIService
{
    Task<string> AskAsync(string question);
}