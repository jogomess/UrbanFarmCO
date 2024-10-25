using System.Collections.ObjectModel;
using System.Windows.Input;
using UrbanFarmMobile.Models;
using UrbanFarmMobile.Services;

namespace UrbanFarmMobile.ViewModels
{
    public class FornecedoresViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Fornecedor> Fornecedores { get; set; }

        public ICommand AddFornecedorCommand { get; }
        public ICommand EditFornecedorCommand { get; }

        public FornecedoresViewModel()
        {
            _apiService = new ApiService();
            Fornecedores = new ObservableCollection<Fornecedor>();
            AddFornecedorCommand = new Command(OnAddFornecedor);
            EditFornecedorCommand = new Command<Fornecedor>(OnEditFornecedor);

            // Carregar dados
            LoadFornecedores();
        }

        private async void LoadFornecedores()
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

        private async void OnAddFornecedor()
        {
            // Lógica para adicionar um novo fornecedor
            await Shell.Current.GoToAsync("//AddFornecedorPage");
        }

        private async void OnEditFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return;

            // Lógica para editar fornecedor
            await Shell.Current.GoToAsync($"//EditFornecedorPage?FornecedorId={fornecedor.FornecedorID}");
        }
    }
}
