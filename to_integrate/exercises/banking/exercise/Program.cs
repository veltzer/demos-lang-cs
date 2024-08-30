
using lab1.banking;
using Bank=lab1.banking.Bank;
using AccountBase = lab1.banking.AccountBase;
using Lab1.banking;

IAccount a;
a = Bank.Instance.CreateAccount(AccountType.Checking);
a.GetBalance();
a = Bank.Instance.CreateAccount(AccountType.Saving);
a.GetBalance();

a = Bank.Instance.DecorateAccount(DecoratorType.Commission, AccountType.Checking);
a.GetBalance();

a = Bank.Instance.DecorateAccount(DecoratorType.Trace, AccountType.Saving);
a.GetBalance();
