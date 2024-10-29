using System;
using System.Collections.Generic;

namespace LegacySystem
{
    // Cliente
    class Cliente(int id, string nome, string email)
    {
        public int Id { get; } = id;
        public string Nome { get; private set; } = nome;
        public string Email { get; private set; } = email;
        public DateTime DataCadastro { get; } = DateTime.Now;

        public void AtualizarNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                Nome = nome;
            }
        }

        public void AtualizarEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
            {
                Email = email;
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Id: {Id} Nome: {Nome} Email: {Email} Cadastro: {DataCadastro}");
        }
    }

    // Transacao
    class Transacao(int id, decimal valor, string descricao)
    {
        public int Id { get; } = id;
        public decimal Valor { get; } = valor;
        public DateTime Data { get; } = DateTime.Now;
        public string Descricao { get; } = descricao;

        public void ExibirTransacao()
        {
            Console.WriteLine($"Id: {Id} Valor: {Valor} Descrição: {Descricao} Data: {Data}");
        }
    }

    //  SistemaTransacoes
    class SistemaTransacoes
    {
        private readonly List<Transacao> _transacoes = new List<Transacao>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            var transacao = new Transacao(id, valor, descricao);
            _transacoes.Add(transacao);
        }

        public void ExibirTransacoes()
        {
            foreach (var transacao in _transacoes)
            {
                transacao.ExibirTransacao();
            }
        }
    }

    // Classe SistemaCliente
    class SistemaCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void AdicionarCliente(int id, string nome, string email)
        {
            _clientes.Add(new Cliente(id, nome, email));
        }

        public void RemoverCliente(int id)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        public void ExibirTodosOsClientes()
        {
            foreach (var cliente in _clientes)
            {
                cliente.ExibirDados();
            }
        }

        public void AtualizarNomeCliente(int id, string nome)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            cliente?.AtualizarNome(nome);
        }
    }

    // Relatorio
    class Relatorio
    {
        public static void GerarRelatorioClientes(List<Cliente> clientes)
        {
            Console.WriteLine("Relatório de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome} | Email: {cliente.Email}");
            }
        }
    }
}
