using CommunityToolkit.Maui;
using PlanShare.App.Constants;
using PlanShare.App.Navigation;
using PlanShare.App.Resources.Styles.Handlers;
using PlanShare.App.ViewModels.Pages.Login.DoLogin;
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
            .AddFonts()
            .ConfigureHandlers();

        return builder.Build();
    }

    private static MauiAppBuilder AddPages(this MauiAppBuilder appBuilder)
    {
        Routing.RegisterRoute(RoutePages.USER_REGISTER_ACCOUNT_PAGE, typeof(RegisterUserAccountPage));

        appBuilder.Services.AddTransientWithShellRoute<DoLoginPage, DoLoginViewModel>(RoutePages.LOGIN_PAGE);

        return appBuilder;
    }

    private static MauiAppBuilder AddFonts(this MauiAppBuilder appBuilder)
    {
        return appBuilder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("Raleway-Regular.ttf", FontFamily.MAIN_FONT_REGULAR);
            fonts.AddFont("Raleway-Black.ttf", FontFamily.MAIN_FONT_BLACK);
            fonts.AddFont("Raleway-Light.ttf", FontFamily.MAIN_FONT_LIGHT);
            fonts.AddFont("WorkSans-Regular.ttf", FontFamily.SECONDARY_FONT_REGULAR);
            fonts.AddFont("WorkSans-Black.ttf", FontFamily.SECONDARY_FONT_BLACK);
        });
    }

    private static MauiAppBuilder ConfigureHandlers(this MauiAppBuilder appBuilder)
    {
        return appBuilder.ConfigureMauiHandlers(_ =>
        {
            CustomEntryHandler.Customize();
        });
    }
}
