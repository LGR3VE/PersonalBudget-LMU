using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBudget.Models;

namespace PersonalBudget.Services
{
    /// <summary>
    /// The main transaction service handling all transactions
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// The List where all transactions are stored im memory
        /// </summary>
        List<Transaction> TransactionList { get; set; }
        
        /// <summary>
        /// Returns the list of all transactions
        /// </summary>
        /// <returns>The List of all transactions</returns>
        Task<List<Transaction>> GetTransactionList();
        
        /// <summary>
        /// Add Transaction by providing a transaction object
        /// </summary>
        /// <param name="transaction">Transaction Object</param>
        void AddTransaction(Transaction transaction);
        
        /// <summary>
        /// AddTransaction by providing single parameters
        /// </summary>
        /// <param name="timestamp">Transaction timestamp</param>
        /// <param name="description">Transaction Description</param>
        /// <param name="amount">Transaction Amount</param>
        /// <param name="label">Transaction Labels separated with a comma</param>
        void AddTransaction(DateTime? timestamp, string description, decimal amount, string label);
        
        /// <summary>
        /// AddTransaction without the need to add a Datetime object
        /// </summary>
        /// <param name="description">Transaction Description</param>
        /// <param name="amount">Transaction Amount</param>
        /// <param name="label">Transaction Labels separated with a comma</param>
        void AddTransaction(string description, decimal amount, string label);
        
        
        /// <summary>
        /// Calculates the sum of all transactions
        /// </summary>
        /// <returns>Sum of all transaction</returns>
        decimal GetCurrentBalance();
        
        /// <summary>
        /// Calculates the sum of all transactions from the last 30 days
        /// </summary>
        /// <returns>Sum of last 30 days transactions</returns>
        decimal GetBalanceOfLast30Days();
        
        /// <summary>
        /// Calculates the sum of positive transactions
        /// </summary>
        /// <returns>Sum of positive transaction</returns>
        decimal GetTotalIncome();
        
        /// <summary>
        /// Calculates the sum of negative transactions
        /// </summary>
        /// <returns>Sum of negative transaction</returns>
        decimal GetTotalExpense();
        
        /// <summary>
        /// Removes a transaction from the transaction list
        /// </summary>
        /// <param name="transaction">Transaction to be removed from list</param>
        /// <returns>True if transaction was successfully removed</returns>
        bool DeleteTransaction(Transaction transaction);
        
        /// <summary>
        /// Asynchronously load the initial transactions from webserver via HTTP GET
        /// </summary>
        Task LoadTransactionListAsync();
        
        /// <summary>
        /// Sets the transaction list
        /// </summary>
        /// <param name="transactions">The list of new transactions</param>
        void SetTransactionList(List<Transaction> transactions);
        
        /// <summary>
        /// Adds an transaction list to the already existing transaction list
        /// </summary>
        /// <param name="transactions">The list of the to be imported transactions</param>
        void AddTransactionList(List<Transaction> transactions);
        
        /// <summary>
        /// The event listener for changing transactions
        /// </summary>
        event Action TransactionHasChanged;
        
        /// <summary>
        /// Invokes the TransactionHasChanged Event
        /// </summary>
        void OnTransactionHasChanged();
        
        /// <summary>
        /// Converts the transaction list into byte[]
        /// </summary>
        /// <returns>Transaction data as byte[]</returns>
        byte[] GetDownloadData();
    }
}