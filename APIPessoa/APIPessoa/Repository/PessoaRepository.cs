using Microsoft.AspNetCore.Components.Routing;
using MySqlConnector;
using Dapper;
using MySqlConnector;

namespace APIPessoa.Repository
{
    public class PessoaRepository
    {
        public List<Pessoa> SelecionarPessoas()
        {
            string query = "SELECT * FROM Pessoa";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            return conn.Query<Pessoa>(query).ToList();
        }
        public void InserirPessoas(Pessoa pessoa)
        {
            string query = $"INSERT INTO Pessoa(Nome, DataNascimento, QuantidadeFilhos) " +
                $"VALUES ('{pessoa.Nome}','{pessoa.DataNascimento.ToString("yyyy-MM-dd")}'," +
                $"{pessoa.QuantidadeFilhos})";
            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            conn.Query(query);
        }
    }
}