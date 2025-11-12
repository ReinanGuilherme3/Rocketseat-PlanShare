using PlanShare.App.Data.Network.Api;
using PlanShare.App.Data.Storage.Preferences.User;
using PlanShare.App.Data.Storage.SecureStorage.Tokens;
using PlanShare.Communication.Requests;

namespace PlanShare.App.UseCases.User.Login.DoLogin;

public interface IDoLoginUseCase
{
    Task Execute(Models.Login model);
}

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly ILoginApi _loginApi;
    private readonly IUserStorage _userStorage;
    private readonly ITokensStorage _tokensStorage;

    public DoLoginUseCase(ILoginApi loginApi, IUserStorage userStorage, ITokensStorage tokensStorage)
    {
        _loginApi = loginApi;
        _userStorage = userStorage;
        _tokensStorage = tokensStorage;
    }

    public async Task Execute(Models.Login model)
    {
        var request = new RequestLoginJson
        {
            Email = model.Email,
            Password = model.Password
        };

        var response = await _loginApi.Login(request);

        if (response.IsSuccessful)
        {
            var user = new Models.ValueObjects.User(response.Content.Id, response.Content.Name);
            var tokens = new Models.ValueObjects.Tokens(response.Content.Tokens.AccessToken, response.Content.Tokens.RefreshToken);

            _userStorage.Save(user);
            await _tokensStorage.Save(tokens);
        }
    }
}
