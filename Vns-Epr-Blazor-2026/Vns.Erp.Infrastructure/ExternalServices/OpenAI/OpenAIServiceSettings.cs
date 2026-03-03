namespace Vns.Erp.Infrastructure.ExternalServices.OpenAI;

/// <summary>
/// Configuration settings for OpenAI service integration.
/// Bound from appsettings.json "OpenAISettings" section.
/// </summary>
public class OpenAIServiceSettings
{
    public const string SectionName = "OpenAISettings";

    public string Endpoint { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string DeploymentName { get; set; } = string.Empty;
}
