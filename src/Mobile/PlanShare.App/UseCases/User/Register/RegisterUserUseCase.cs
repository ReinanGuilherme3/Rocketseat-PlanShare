using PlanShare.App.Data.Network.Api;
using PlanShare.App.Data.Storage.Preferences.User;
using PlanShare.App.Data.Storage.SecureStorage.Tokens;
using PlanShare.App.Models;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task Execute(UserRegisterAccount model);
}
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserApi _userApi;
    private readonly IUserStorage _userStorage;
    private readonly ITokensStorage _tokensStorage;

    public RegisterUserUseCase(IUserApi userApi, IUserStorage userStorage, ITokensStorage tokensStorage)
    {
        _userApi = userApi;
        _userStorage = userStorage;
        _tokensStorage = tokensStorage;
    }

    public async Task Execute(UserRegisterAccount model)
    {
        var request = new RequestRegisterUserJson
        {
            Name = model.Name,
            Email = model.Email,
            Password = model.Password
        };

        var response = await _userApi.Register(request);
        if (response.IsSuccessful)
        {
            var user = new Models.ValueObjects.User(response.Content.Id, response.Content.Name);
            var tokens = new Models.ValueObjects.Tokens(response.Content.Tokens.AccessToken, response.Content.Tokens.RefreshToken);

            _userStorage.Save(user);
            await _tokensStorage.Save(tokens);
        }

    }
}
