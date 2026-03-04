namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        // Inicializa os componentes visuais definidos no XAML
        InitializeComponent();
    }

    // Método executado quando o ToolbarItem "Adicionar" é clicado
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Realiza a navegação para a página NovoProduto
            // PushAsync adiciona a nova página na pilha de navegação
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro, exibe uma mensagem para o usuário
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}