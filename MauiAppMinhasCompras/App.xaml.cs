using MauiAppMinhasCompras.Helpers; 
namespace MauiAppMinhasCompras
{
 
    public partial class App : Application
    {
        // Instância estática do banco (Singleton)
        static SQLiterDatabaseHelper _db;

        // Propriedade pública para acessar o banco em qualquer parte do app
        public static SQLiterDatabaseHelper Db
        {
            get
            {
                // Verifica se a instância ainda não foi criada
                if (_db == null)
                {
                    // Define o caminho onde o banco será armazenado no dispositivo
                    string path = Path.Combine(
                        // Obtém a pasta local da aplicação (compatível com Android, Windows e iOS)
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),

                        // Nome do arquivo do banco de dados
                        "banco_sqlite_compras.db3");

                    // Cria a instância do banco passando o caminho do arquivo
                    _db = new SQLiterDatabaseHelper(path);
                }

                // Retorna a instância já criada
                return _db;
            }
        }
        
        public App()
        {
            // Carrega os componentes definidos no App.xaml
            InitializeComponent();

            // Define a página inicial da aplicação
            MainPage = new NavigationPage(new Views.ListaProduto());

         
        }
    }
}