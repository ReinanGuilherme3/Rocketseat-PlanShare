namespace PlanShare.App.Views.Pages.User.Register;

public partial class RegisterUserAccountPage : ContentPage
{
    public RegisterUserAccountPage(RegisterUserAccountPage viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}