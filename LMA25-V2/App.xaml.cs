using LMA25_V2.Pages;

namespace LMA25_V2;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;

        // Use DI to resolve MainPage
        //MainPage = _serviceProvider.GetRequiredService<MainPage>();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
