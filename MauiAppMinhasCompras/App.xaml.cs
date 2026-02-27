namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
                //MainPage = new appShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}