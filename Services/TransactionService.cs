using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonalBudget.Models;

namespace PersonalBudget.Services
{
    /// <inheritdoc />
    public class TransactionService : ITransactionService
    {
        /// <inheritdoc />
        public List<Transaction> TransactionList { get; set; }
        
        /// The httpClient instance
        private readonly HttpClient _httpClient;
        
        /// <inheritdoc />
        public event Action TransactionHasChanged;

        /// <summary>
        /// Initializes the TransactionService
        /// </summary>
        /// <param name="httpClient">Dependency Injection of the httpClient</param>
        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            TransactionList = new List<Transaction>();
        }

        /// <inheritdoc />
        public async Task<List<Transaction>> GetTransactionList()
        {
            //if transaction list is empty populate ist with sample data from the server
            if (TransactionList.Count == 0)
            {
                await LoadTransactionListAsync();
            }
            return TransactionList;
        }
        
        /// <inheritdoc />
        public void AddTransaction(Transaction transaction)
        {
            TransactionList.Add(transaction);
        }

        /// <inheritdoc />
        public void AddTransaction(DateTime? timestamp, string description, decimal amount, string label)
        {
            TransactionList.Add(
                new Transaction()
                {
                    Date = timestamp ?? DateTime.Now,
                    Description = description,
                    Amount = amount,
                    Label = label
                });
        }
        
        /// <inheritdoc />
        public void AddTransaction(string description, decimal amount, string label)
        {
            TransactionList.Add(
                new Transaction()
                {
                    Date = DateTime.Now,
                    Description = description,
                    Amount = amount,
                    Label = label
                });
        }

        /// <inheritdoc />
        public decimal GetCurrentBalance()
        {
            return TransactionList.Sum(transaction => transaction.Amount);
        }
        
        /// <inheritdoc />
        public decimal GetBalanceOfLast30Days()
        {
            return TransactionList
                .Where(t => (DateTime.Now - t.Date) <= TimeSpan.FromDays(30))
                .Sum(transaction => transaction.Amount);
        }

        /// <inheritdoc />
        public decimal GetTotalIncome()
        {
            return TransactionList
                .Where(t => t.Amount > 0)
                .Sum(transaction => transaction.Amount);
        }

        /// <inheritdoc />
        public decimal GetTotalExpense()
        {
            return TransactionList
                .Where(t => t.Amount < 0)
                .Sum(transaction => transaction.Amount);
        }

        /// <inheritdoc />
        public bool DeleteTransaction(Transaction transaction)
        {
            return TransactionList.Remove(transaction);
        }
        
        /// <inheritdoc />
        public async Task LoadTransactionListAsync()
        {
            TransactionList = await _httpClient.GetFromJsonAsync<List<Transaction>>("data/TransactionData.json");
        }
        
        /// <inheritdoc />
        public void SetTransactionList(List<Transaction> transactions)
        {
            TransactionList = transactions;
        }
        
        /// <inheritdoc />
        public void AddTransactionList(List<Transaction> transactions)
        {
            TransactionList.AddRange(transactions);
        }

        /// <inheritdoc />
        public void OnTransactionHasChanged()
        {
            TransactionHasChanged?.Invoke();
        }

        /// <inheritdoc />
        public byte[] GetDownloadData()
        {
            var json = JsonConvert.SerializeObject(TransactionList);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }
    }
}