using Vns_Epr_Blazor_2026.Shared.Services;

namespace Vns_Epr_Blazor_2026.Web.Client.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "WebAssembly";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
