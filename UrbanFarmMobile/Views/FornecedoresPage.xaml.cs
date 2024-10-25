using UrbanFarmMobile.ViewModels;
using Microsoft.Maui.Controls;

namespace UrbanFarmMobile.Views
{
    public partial class FornecedoresPage : ContentPage
    {
        public FornecedoresPage()
        {
            InitializeComponent();
            BindingContext = new FornecedoresViewModel();
        }
    }
}
