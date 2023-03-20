using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace IMGENUMERALLECTURE2
{//EDNA LYNN LAXA 
// MARCH 6, 2023 
//CSI 122 - PROGRAMMING II 
//ENUMERABLE LECTURE 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ACCOUNT> accounts = new List<ACCOUNT>();

       

        public MainWindow()
        {
            InitializeComponent();
            PopulateAccountTypes(); 
         
            //ACCOUNT ednalynn = new ACCOUNT(ACCOUNT.AccountType.Saving, "Edna Lynn", 100000);
            //ACCOUNT mylo = new ACCOUNT(ACCOUNT.AccountType.Saving, "Mylo Dear", 30000);

        }
        public void PopulateAccountTypes()
        {
            cmbAccountTypes.Items.Add("Saving");
            cmbAccountTypes.Items.Add("Checkings");
            cmbAccountTypes.Items.Add("Investment");

            cmbAccountTypes.SelectedIndex = 0; 

        }
        // When clicked , reates a new instance of an account with the required information .
        // Adds it to the account list. 
        //Updates the account listbox display 
        private void BtnAddAcount_Click(object sender, RoutedEventArgs e)
        {
            //BUTTON CLICK to ADD NAME , BALANCE & TYPE OF ACCOUNT TO LB. 

            string fullName = txtName.Name;
            decimal balance = decimal.Parse(txtBalance.Text);
            int accountType = cmbAccountTypes.SelectedIndex;
            ACCOUNT.AccountType convertedType = (ACCOUNT.AccountType)accountType;

            string filePath = txtFilePath.Text;

            //A new instance of ___ type 
            //new Type () 
            ACCOUNT account = new ACCOUNT(convertedType,fullName, balance, filePath);

            imgCustomer.Source = account.CustomerPicture; 

            lbAccounts.Items.Add(account.ToString()); 
        }

        private void btnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog(); 

            if(op.ShowDialog() == true)
            {

                txtFilePath.Text = op.FileName;
            }
        }
        int selectedIndex = 0;
        private void lbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(lbAccounts.SelectedIndex > -1)
            {
               selectedIndex = lbAccounts.SelectedIndex; 

            }
            imgCustomer.Source = accounts[selectedIndex].CustomerPicture;
        }
    }
}
