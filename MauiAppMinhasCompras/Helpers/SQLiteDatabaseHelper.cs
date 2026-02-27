using MauiAppMinhasCompras.Models; // Importa os modelos da aplicação
using SQLite; // Importa a biblioteca do SQLite
 //caso a cor das using esteja apagadas significa que o programa ou aplicacao que voce busca usar nao esta implementado no codigo para o uso do arquivo

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiterDatabaseHelper
    {
        // Conexão assíncrona com o banco de dados SQLite
        readonly SQLiteAsyncConnection _conn;

        // Construtor que recebe o caminho do banco
        public SQLiterDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path); // Cria a conexão com o banco
            _conn.CreateTableAsync<Produto>().Wait(); // Cria a tabela Produto se não existir
        }

        // Insere um produto no banco
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p); // Executa insert assíncrono
        }

        // Atualiza um produto existente
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade =?, Preco=?, WHERE Id=?";
            // Comando SQL para atualizar um produto pelo Id

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            ); // Executa o update passando os parâmetros
        }

        // Deleta um produto pelo Id
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
            // Remove o registro correspondente ao Id
        }

        // Retorna todos os produtos cadastrados
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
            // Converte a tabela em lista
        }

        // Busca produtos pela descrição
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%%'" + q + "%'";
            // Comando SQL para buscar produtos que contenham o texto informado

            return _conn.QueryAsync<Produto>(sql);
            // Executa a consulta e retorna a lista
        }
    }
}
