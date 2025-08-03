using CommunityToolkit.Maui;
using PlanShare.App.Constants;
using PlanShare.App.Navigation;
using PlanShare.App.Views.Pages.Login.DoLogin;
using PlanShare.App.Views.Pages.User.Register;

namespace PlanShare.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .AddPages()
            .AddFonts();

        return builder.Build();
    }

    private static MauiAppBuilder AddPages(this MauiAppBuilder appBuilder)
    {
        Routing.RegisterRoute(RoutePages.LOGIN_PAGE, typeof(DoLoginPage));
        Routing.RegisterRoute(RoutePages.USER_REGISTER_ACCOUNT_PAGE, typeof(RegisterUserAccountPage));

        return appBuilder;
    }

    private static void AddFonts(this MauiAppBuilder appBuilder)
    {
        appBuilder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("Raleway-Regular.ttf", FontFamily.MAIN_FONT_REGULAR);
            fonts.AddFont("Raleway-Black.ttf", FontFamily.MAIN_FONT_BLACK);
            fonts.AddFont("Raleway-Light.ttf", FontFamily.MAIN_FONT_LIGHT);
            fonts.AddFont("WorkSans-Regular.ttf", FontFamily.SECONDARY_FONT_REGULAR);
            fonts.AddFont("WorkSans-Black.ttf", FontFamily.SECONDARY_FONT_BLACK);
        });
    }
}
