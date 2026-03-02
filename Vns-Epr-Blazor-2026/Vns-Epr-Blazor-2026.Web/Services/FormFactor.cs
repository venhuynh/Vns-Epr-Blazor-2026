using Vns_Epr_Blazor_2026.Shared.Services;

namespace Vns_Epr_Blazor_2026.Web.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Web";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
