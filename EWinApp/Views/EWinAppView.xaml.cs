using EWinApp.ViewModels;

namespace EWinApp.Views
{
    public sealed partial class EWinAppView
    {
        public EWinAppView(EWinAppViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}