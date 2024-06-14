// See https://aka.ms/new-console-template for more information
using banking;

IAccount acc = Bank.Instance.CreateAccount(AccountType.Saving);

acc.Deposit(10);

Console.WriteLine(acc.GetBalance());