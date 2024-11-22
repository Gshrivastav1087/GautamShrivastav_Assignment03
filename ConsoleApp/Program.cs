public class Program
{
    static void Main(string[] args)
    {
        IBankAccountManager bank = new BankAccountManager();  
        TransactionsManager atmApp = new TransactionsManager(bank);
        atmApp.Start();
    }
}
