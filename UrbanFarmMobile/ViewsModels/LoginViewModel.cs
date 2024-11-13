using Microsoft.Maui.Controls;
using System.Windows.Input;
using UrbanFarmMobile.Services;

namespace UrbanFarmMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand EntrarCommand { get; }

        public LoginViewModel()
        {
            _apiService = new ApiService();
            EntrarCommand = new Command(OnEntrar);
        }

        private async void OnEntrar()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "E-mail e senha são obrigatórios.";
                return;
            }

            var loginResult = await _apiService.LoginAsync(Email, Password);

            if (loginResult.Success)
            {
                // Redirecionar diretamente para a Dashboard após o login bem-sucedido
                await Shell.Current.GoToAsync("//Views/DashboardPage");
            }
            else
            {
                // Exibir mensagem de erro ao usuário
                ErrorMessage = loginResult.Message;
            }
        }
    }
}