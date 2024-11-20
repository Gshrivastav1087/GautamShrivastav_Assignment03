using System;
using System.Collections.Generic;
using System.Transactions;

public class BankAccountOperations : IBankAccountOperations
{
    public int AccountNumber { get; private set; }
    public string AccountHolderName { get; private set; }
    public double Balance { get; private set; }
    public double InterestRate { get; private set; }
    public string Password { get; private set; }

    private List<string> transactionHistory;
    private DateTime lastInterestCalculation;
    public BankAccountOperations(int accountNumber, double initialBalance, string accountHolderName, double interestRate, string password)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        AccountHolderName = accountHolderName;
        InterestRate = interestRate;
        Password = password;
        transactionHistory = new List<string>();
    }

    public void DepositMoney(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            transactionHistory.Add($"Deposited: {amount.ToString("C")}");
        }
        else
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }
    }

    public void WithdrawMoney(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            transactionHistory.Add($"Withdraw of {amount:C}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void DisplayStatement()
    {
        Console.WriteLine($"*** Bank Statement ***");
        Console.WriteLine($"Account Holder: {AccountHolderName}");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Balance: {Balance:C}");
        Console.WriteLine($"Interest Rate: {InterestRate * 100}%");
        Console.WriteLine("Transaction History:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine(transaction);  
        }
    }


}
