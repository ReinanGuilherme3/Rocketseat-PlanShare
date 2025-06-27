using CommunityToolkit.Mvvm.Input;

namespace PlanShare.App.ViewModels.Pages.OnBoarding;

public partial class OnBoardingViewModel
{
    [RelayCommand]
    public async Task LoginWithEmailAndPassword()
    {
        await Shell.Current.GoToAsync("DoLoginPage");
    }

    [RelayCommand]
    public void LoginWithGoogle()
    {
        // Logic for logging in with email and password
    }
}
