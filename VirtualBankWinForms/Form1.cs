using DataCanVirtualBank;
using VirtualBankWinForms.Properties;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace VirtualBankWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_Welcome(object sender, EventArgs e)
        {
            var customer = new Customer();
            customer.SetName("Lina");
            customer.SetLastName("Silva");
            var txt = string.Concat("Welcome, " + customer.GetName() + " " + customer.GetLastName() + "!");
            txt_welcome.Text = txt;
        }

        private void txt_balance_TextChanged(object sender, EventArgs e)
        {
            var customer = new Customer();
            customer.SetName("Lina");
            customer.SetLastName("Silva");
            customer.CheckingAccounts.Add(new CheckingAccount(421, 5076));
            var balance = customer.CheckingAccounts[0].GetBalance();
            txt_balance.Text = balance.ToString();
        }

        private void cbb_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = new Customer();
            customer.SetName("Lina");
            customer.SetLastName("Silva");
            customer.CheckingAccounts.Add(new CheckingAccount(421, 5076));
            List<CheckingAccount> customerAccounts = new List<CheckingAccount>();
            //cbb_account.DataSource = customerAccounts;
            //cbb_account.ValueMember = "id";
            //cbb_account.DisplayMember = "balance";
            //var accountId = customer.CheckingAccounts[0].GetAccountId();
            //obtener lista de cuentas
            //cbb_account.Items = accountId.ToString();//List<accountId.ToString()>;
        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            float amount = 0;
            try
            {
                amount = float.Parse(txt_amount.Text); 
                // Possible improvement: Search regular expression to verify all entries 12,2,3, should'n be working
            }
            catch
            {
                MessageBox.Show("This field must be a number. Format: 1,234.50");
            }

        }

        private void cbb_currency_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<ExchangeRate> exchangeRateslst = new List<ExchangeRate>();
            exchangeRateslst.Add(new ExchangeRate() { _id = 1, _currency = "USD" });
            exchangeRateslst.Add(new ExchangeRate() { _id = 2, _currency = "MXN" });
            exchangeRateslst.Add(new ExchangeRate() { _id = 3, _currency = "EUR" });
            exchangeRateslst.Add(new ExchangeRate() { _id = 4, _currency = "CAD" });
            cbb_currency.DataSource = exchangeRateslst;
            cbb_currency.ValueMember = "_id";
            cbb_currency.DisplayMember = "_currency"; //"_rateValue"; 

        }

        /*static public class CurrenciesList {
            List<ExchangeRate> exchangeRateslst = new List<ExchangeRate>();
        }*/

        private void cbb_currency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ExchangeRate obj = cbb_currency.SelectedItem as ExchangeRate;
            if (obj != null)
            {
                MessageBox.Show(string.Format("Currency = {0}", obj._id, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }


        private void btn_withdraw_Click(object sender, EventArgs e)
        {
            cbb_currency_SelectionChangeCommitted(cbb_currency, e); //This parameter should be the one to use in line 92
            var customer = new Customer();
            customer.SetName("Lina");
            customer.SetLastName("Silva");
            customer.CheckingAccounts.Add(new CheckingAccount(421, 5076));
            //    var newBalance = customer.CheckingAccounts[0].Withdraw(float.Parse(txt_amount.Text), cbb_currency.Text);
            //    txt_balance.Text = newBalance.ToString();

        }

        private void btn_load_customer_Click(object sender, EventArgs e)
        {
            textBox1_Welcome(txt_welcome, e);
            txt_balance_TextChanged(txt_balance, e);
            cbb_account_SelectedIndexChanged(cbb_account, e);
            
        }
    }
}
