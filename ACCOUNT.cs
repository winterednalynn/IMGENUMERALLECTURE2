using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IMGENUMERALLECTURE2
{
    public class ACCOUNT
    { //ENUMERABLE = Category Names 
        //enum Type {Saving, Checking} -- example 

        //TO DECLARE A ENUMERABLE 
        public enum AccountType {Saving, Checking, Investment};

        //DIFFERENCE BETWEEN SAVINGS & CHECKINGS 
        //-------------------------------------
        //REQ. MIN BALANCE 
        //INTEREST RATE
        //WITHDRAW RATE 

        string _accountNumber;
        AccountType _typeOfAccount;
        string _name;
        decimal _balance;

        decimal _savingMinBalance;
        decimal _interestRate;
        decimal _withdrawFee = 200;

        BitmapImage _customerPicture;

        public BitmapImage CustomerPicture { get => _customerPicture; set => _customerPicture = value; }

        public ACCOUNT(AccountType typeOfAccount, string name, decimal balance, string filePath)
        {
            Random rand = new Random(); 

            _accountNumber = rand.Next(100000, 100000000).ToString();
            _typeOfAccount = typeOfAccount;
            _name = name;

            _customerPicture = ConvertCustomerImage(filePath) ;
      
        }
        private BitmapImage ConvertCustomerImage(string filePath)
        {
            Uri uri = new Uri(filePath);
            BitmapImage bitmap = new BitmapImage(uri);
            return bitmap; 
        }

        public void Withdraw(decimal amount)
        {
            if( amount <  _balance)
            {
                _balance -= _withdrawFee; 
            }
            else
            {
                if(_typeOfAccount == AccountType.Checking)
                {
                    _balance -= _withdrawFee;
                }
            }


        }
        public override string ToString()
        {
            return $"{_accountNumber} - {_typeOfAccount}- {_balance}";
        }
    }
}
