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
            LoadData();
        }

        private async void LoadData()
        {
            var fornecedoresResponse = await _apiService.GetFornecedoresAsync();
            if (fornecedoresResponse != null && fornecedoresResponse.Success)
            {
                foreach (var fornecedor in fornecedoresResponse.Data)
                {
                    Fornecedores.Add(fornecedor);
                }
            }

            var funcionariosResponse = await _apiService.GetFuncionariosAsync();
            if (funcionariosResponse != null && funcionariosResponse.Success)
            {
                foreach (var funcionario in funcionariosResponse.Data)
                {
                    Funcionarios.Add(funcionario);
                }
            }

            var produtosResponse = await _apiService.GetProdutosAsync();
            if (produtosResponse != null && produtosResponse.Success)
            {
                foreach (var produto in produtosResponse.Data)
                {
                    Produtos.Add(produto);
                }
            }
        }
    }
}
