using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

// Página responsável por cadastrar um novo produto
public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent(); 
    }

    // Evento acionado ao clicar no botão da Toolbar (Salvar)
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Criando um novo objeto Produto e preenchendo com os dados digitados
            Produto p = new Produto
            {
                // Pega o texto digitado no campo descrição
                Descricao = txt_descricao.Text,

                // Converte o texto digitado para número (double)
                Quantidade = Convert.ToDouble(txt_quantidade.Text),

                // Converte o texto do preço para número (double)
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Insere o produto no banco de dados
            await App.Db.Insert(p);

            // Exibe mensagem de sucesso
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

        }
        catch (Exception ex) // Caso aconteça algum erro
        {
            // Exibe a mensagem de erro
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}