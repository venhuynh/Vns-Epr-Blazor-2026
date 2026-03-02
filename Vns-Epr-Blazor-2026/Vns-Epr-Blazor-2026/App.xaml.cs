namespace Vns_Epr_Blazor_2026
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Vns-Epr-Blazor-2026" };
        }
    }
}
