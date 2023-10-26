using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labatym8
{

    public enum AccountType
    {
        Текущий_счет,
        Сберегательный_счет
    }


    class BankAccount
    {
        #region Поля
        private static int numberOfBankAccounts;
        private int accountNumber;
        private decimal accountBalance;
        private AccountType bankAccountType;
        #endregion

        #region Свойства

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }


        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }


        public AccountType BankAccountType
        {
            get
            {
                return bankAccountType;
            }
        }

        public static int NumberOfBankAccounts { get => numberOfBankAccounts; set => numberOfBankAccounts = value; }
        #endregion

        #region Методы

        private void ChangeNumberOfBankAccounts()
        {
            NumberOfBankAccounts++;
        }


        public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }


        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                return true;
            }

            return false;
        }


        public bool TransferringMoney(BankAccount withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }
        #endregion

        #region Конструкторы

        public BankAccount(AccountType bankAccountType)
        {
            accountNumber = NumberOfBankAccounts;
            accountBalance = 0;
            this.bankAccountType = bankAccountType;
            ChangeNumberOfBankAccounts();
        }
        #endregion
    }
}
