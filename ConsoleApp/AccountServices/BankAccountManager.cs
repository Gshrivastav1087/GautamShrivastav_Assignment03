public class BankAccountManager : IBankAccountManager
{
    private List<IBankAccountOperations> accounts;

    public BankAccountManager()
    {
        accounts = new List<IBankAccountOperations>();

        for (int i = 100; i <= 1000; i++)
        {
            accounts.Add(new BankAccountOperations(i, 100, $"IamRandomUser{i}", 0.03, "assignment03"));
        }
    }

    public IBankAccountOperations RetrieveAccount(int accountNumber)
    {
        foreach (var account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }
        return null;  // Account not found
    }

    public void AddAccount(IBankAccountOperations account)
    {
        accounts.Add(account);
    }
}
