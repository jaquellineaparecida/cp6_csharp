using System;
using System.Collections.Generic;

namespace SimpleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientService = new ClientService();
            clientService.AddClient(1, "Joao", "joao@gmail.com");
            clientService.AddClient(2, "Maria", "maria@gmail.com");

            var transactionService = new TransactionService();
            transactionService.AddTransaction(1, 100.50m, "Compra de Produto");
            transactionService.AddTransaction(2, 200.00m, "Compra de Serviço");

            clientService.ShowAllClients();
            transactionService.ShowAllTransactions();

            clientService.RemoveClient(1);
            clientService.ShowAllClients();

            clientService.UpdateClientName(2, "Maria Silva");

            PrintCompanyInfo();

            var report = new Report();
            Report.GenerateClientReport(clientService.clients);

            Console.WriteLine("Total: " + CalculateSum(10));
        }

        static void PrintCompanyInfo()
        {
            const string CompanyName = "Leroy Merlin";
            const string TransactionDescription = "Compra de tintas";
            const int RepeatCount = 3;

            for (int i = 0; i < RepeatCount; i++)
            {
                Console.WriteLine("Empresa: " + CompanyName + ", Descrição: " + TransactionDescription);
            }
        }

        static int CalculateSum(int count)
        {
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += i;
            }
            return sum;
        }
    }

    class ClientService
    {
        public readonly List<Client> clients = new List<Client>();

        public void AddClient(int id, string name, string email)
        {
            clients.Add(new Client(id, name, email));
        }

        public void RemoveClient(int id)
        {
            clients.RemoveAll(c => c.Id == id);
        }

        public void UpdateClientName(int id, string newName)
        {
            var client = clients.Find(c => c.Id == id);
            if (client != null)
            {
                client.Name = newName;
            }
        }

        public void ShowAllClients()
        {
            foreach (var client in clients)
            {
                Console.WriteLine("ID: " + client.Id + ", Nome: " + client.Name + ", Email: " + client.Email);
            }
        }
    }

    class TransactionService
    {
        private readonly List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(int id, decimal value, string description)
        {
            transactions.Add(new Transaction(id, value, description));
        }

        public void ShowAllTransactions()
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine("ID: " + transaction.Id + ", Valor Transação: " + transaction.Value + ", Descrição: " + transaction.Description);
            }
        }
    }

    class Client(int id, string name, string email)
    {
        public int Id { get; } = id;
        public string Name { get; set; } = name;
        public string Email { get; } = email;
    }

    class Transaction(int id, decimal value, string description)
    {
        public int Id { get; } = id;
        public decimal Value { get; } = value;
        public string Description { get; } = description;
    }

    class Report
    {
        public static void GenerateClientReport(List<Client> clients)
        {
            Console.WriteLine("Client Report:");
            foreach (var client in clients)
            {
                Console.WriteLine("ID: " + client.Id + ", Nome: " + client.Name + ", Email: " + client.Email);
            }
        }
    }
}
