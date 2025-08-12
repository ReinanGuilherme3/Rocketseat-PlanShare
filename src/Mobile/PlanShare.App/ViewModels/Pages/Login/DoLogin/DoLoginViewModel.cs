using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanShare.App.Models;

namespace PlanShare.App.ViewModels.Pages.Login.DoLogin;
public partial class DoLoginViewModel : ViewModelBase
{
    [ObservableProperty]
    public LoginModel model;

    public DoLoginViewModel()
    {
        Model = new();
    }

    [RelayCommand]
    public async Task DoLogin()
    {
        var textoDigitado = Model;
    }
}
