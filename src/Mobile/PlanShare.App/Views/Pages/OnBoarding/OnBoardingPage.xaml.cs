namespace PlanShare.App.Views.Pages.OnBoarding;
using ViewModels.Pages.OnBoarding;

public partial class OnBoardingPage : ContentPage
{
    public OnBoardingPage()
    {
        InitializeComponent();

        BindingContext = new OnBoardingViewModel();
    }
}