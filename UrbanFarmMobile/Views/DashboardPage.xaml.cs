using System;
using Microsoft.Maui.Controls;
using UrbanFarmMobile.ViewModels; // Importa o namespace da DashboardViewModel

namespace UrbanFarmMobile.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }

        // Métodos de navegação
        private async void OnFornecedorClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//FornecedorPage");
        }

        private async void OnFuncionarioClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//FuncionarioPage");
        }

        private async void OnProdutoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProdutoPage");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
