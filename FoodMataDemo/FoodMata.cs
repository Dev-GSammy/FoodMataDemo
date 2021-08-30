using System;
using System.Windows.Forms;

namespace FoodMataDemo
{
    public partial class FoodMata : Form
    {
        Database databaseObject = new Database();
        public FoodMata()
        {
            InitializeComponent();
            
        }
        string User_Name, User_Location, Phone_Number, Account_Name, Bank_Name, Website;

        

        long Account_Number;

        private void FoodMata_Load(object sender, EventArgs e)
        {

        }

        public void ClearAll()
        {
            txtName.Clear();
            txtLocation.Clear();
            txtPhoneNumber.Clear();
            txtAccountName.Clear();
            txtAccountNumber.Clear();
            txtBankName.Clear();
            txtWebsite.Clear();
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            DeclareAssign();
            if (User_Name == "" || User_Location == "" || Phone_Number == "" || Account_Name == "" || Bank_Name == "" || Website == "" || txtAccountNumber.Text == "")
            {
                MessageBox.Show("Field(s) cannot be empty.\n Please fill all fields");
            }
            else
            {
                //databaseObject.CreateTable();
                databaseObject.InsertData(User_Name, User_Location, Phone_Number, Account_Name, Account_Number, Bank_Name, Website);
                MessageBox.Show("Your Data has been saved.\nThank you");
                ClearAll();
            }

        }
        public void DeclareAssign()
        {
            User_Name = txtName.Text;
            User_Location = txtLocation.Text;
            Phone_Number = txtPhoneNumber.Text;
            Account_Name = txtAccountName.Text;
            Bank_Name = txtBankName.Text;
            Website = txtWebsite.Text;
            try
            {
                Account_Number = long.Parse(txtAccountNumber.Text);
            }
            catch (Exception ex)
            {
                txtAccountNumber.Clear();
                MessageBox.Show("Account Number must be integer\n" + ex.Message);
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("To Update an entry, your account number must be accurate\nYour data won't be added or edited if account number doesn't exist\n click Okay to continue, Cancel to edit account number", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(dr == DialogResult.OK)
            { 
                DeclareAssign();
                if (User_Name == "" || User_Location == "" || Phone_Number == "" || Account_Name == "" || Bank_Name == "" || Website == "" || txtAccountNumber.Text == "")
                {
                    MessageBox.Show("Field(s) cannot be empty.\n Please fill all fields");
                }
                else
                {
                    //databaseObject.UpdateTable();
                    databaseObject.UpdateData(User_Name, User_Location, Phone_Number, Account_Name, Account_Number, Bank_Name, Website);
                    MessageBox.Show("Your Data has been Updated.\nThank you");
                    ClearAll();
                }
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("To Delete an entry, your account number must be accurate\nYour data won't be added or edited if account number doesn't exist\n click Okay to continue, Cancel to edit account number", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                DeclareAssign();
                if (User_Name == "" || User_Location == "" || Phone_Number == "" || Account_Name == "" || Bank_Name == "" || Website == "" || txtAccountNumber.Text == "")
                {
                    MessageBox.Show("Field(s) cannot be empty.\n Please fill all fields");
                }
                else
                {
                    //databaseObject.UpdateTable();
                    databaseObject.DeleteData(User_Name, User_Location, Phone_Number, Account_Name, Account_Number, Bank_Name, Website);
                    MessageBox.Show("Your Entry has been Deleted.\nThank you");
                    ClearAll();
                }
            }
        }
    }
}
