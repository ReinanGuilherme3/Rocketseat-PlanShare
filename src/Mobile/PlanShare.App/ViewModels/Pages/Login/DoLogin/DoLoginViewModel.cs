using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Models;
using PlanShare.App.UseCases.User.Login.DoLogin;

namespace PlanShare.App.ViewModels.Pages.Login.DoLogin;
public partial class DoLoginViewModel : ViewModelBase
{
    [ObservableProperty]
    public Models.Login model;

    private readonly IDoLoginUseCase _loginUseCase;

    public DoLoginViewModel(IDoLoginUseCase loginUseCase)
    {
        Model = new();

        _loginUseCase = loginUseCase;
    }

    [RelayCommand]
    public async Task DoLogin()
    {
        StatusPage = StatusPage.Sending;

        await _loginUseCase.Execute(Model);

        StatusPage = StatusPage.Default;
    }
}
