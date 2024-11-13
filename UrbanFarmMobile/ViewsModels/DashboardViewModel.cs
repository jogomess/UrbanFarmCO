using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UrbanFarmMobile.Models;
using UrbanFarmMobile.Services;

namespace UrbanFarmMobile.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Fornecedor> Fornecedores { get; set; }
        public ObservableCollection<Funcionario> Funcionarios { get; set; }
        public ObservableCollection<Produto> Produtos { get; set; }

        public DashboardViewModel()
        {
            _apiService = new ApiService();
            Fornecedores = new ObservableCollection<Fornecedor>();
            Funcionarios = new ObservableCollection<Funcionario>();
            Produtos = new ObservableCollection<Produto>();

            // Carregar os dados assim que o ViewModel for instanciado
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await LoadFornecedoresAsync();
            await LoadFuncionariosAsync();
            await LoadProdutosAsync();
        }

        private async Task LoadFornecedoresAsync()
        {
            var fornecedoresResponse = await _apiService.GetFornecedoresAsync();
            if (fornecedoresResponse != null && fornecedoresResponse.Success)
            {
                Fornecedores.Clear();
                foreach (var fornecedor in fornecedoresResponse.Data)
                {
                    Fornecedores.Add(fornecedor);
                }
            }
        }

        private async Task LoadFuncionariosAsync()
        {
            var funcionariosResponse = await _apiService.GetFuncionariosAsync();
            if (funcionariosResponse != null && funcionariosResponse.Success)
            {
                Funcionarios.Clear();
                foreach (var funcionario in funcionariosResponse.Data)
                {
                    Funcionarios.Add(funcionario);
                }
            }
        }

        private async Task LoadProdutosAsync()
        {
            var produtosResponse = await _apiService.GetProdutosAsync();
            if (produtosResponse != null && produtosResponse.Success)
            {
                Produtos.Clear();
                foreach (var produto in produtosResponse.Data)
                {
                    Produtos.Add(produto);
                }
            }
        }
    }
}
