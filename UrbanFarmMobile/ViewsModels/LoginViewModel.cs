using System.Windows.Input;
using UrbanFarmMobile.Services;
using UrbanFarmMobile.Models;
using Microsoft.Maui.Controls;

namespace UrbanFarmMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private string _email;
        private string _password;

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

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            _apiService = new ApiService();
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Por favor, insira o e-mail e a senha.", "OK");
                return;
            }

            var response = await _apiService.LoginAsync(Email, Password);
            if (response != null && response.Success)
            {
                // Navegar para a página inicial após login bem-sucedido
                await Shell.Current.GoToAsync("//DashboardPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "E-mail ou senha incorretos.", "OK");
            }
        }

        private async void OnRegisterClicked()
        {
            // Lógica para navegar para a página de registro
            await Shell.Current.GoToAsync("//RegisterPage");
        }
    }
}
