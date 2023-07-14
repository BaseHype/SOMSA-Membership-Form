using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SOMSA_Membership_Form
{
    public partial class Form1 : Form
    {
        // declare global variables
        string gender = "";
        string filter;
        int index;
        int amount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load data into into the 'appData.Members' table
            // This line of code loads data into the 'appData.Members' table.
            this.membersTableAdapter.Fill(this.appData.Members);

            cmbFilter.SelectedIndex = 0;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Enable and  disable the necessary input and buttons
            txtName.Enabled = true;
            txtSurname.Enabled = true;
            txtIDNumber.Enabled = true;
            txtContact.Enabled = true;
            txtEmail.Enabled = true;
            txtProvince.Enabled = true;
            txtServiceSection.Enabled = true;
            txtMembershipNumber.Enabled = true;
            radMale.Enabled = true;
            radFemale.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;

            // Clear all input fields
            txtName.Clear();
            txtSurname.Clear();
            txtIDNumber.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtProvince.Clear();
            txtServiceSection.Clear();
            txtMembershipNumber.Clear();
            radMale.Checked = false;
            radFemale.Checked = false;

            // Set focus to the name textbox
            txtName.Focus();
        }

        private void radMale_CheckedChanged(object sender, EventArgs e)
        {
            // set the gender to "male"
            gender = "Male";
        }

        private void radFemale_CheckedChanged(object sender, EventArgs e)
        {
            // set the gender to "female"
            gender = "Female";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Disable the necessary inputs and buttons
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtIDNumber.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtProvince.Enabled = false;
            txtServiceSection.Enabled = false;
            txtMembershipNumber.Enabled = false;
            radMale.Enabled = false;
            radFemale.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;

            // Create a new dataRow with the same columns in our 'Members' table
            AppData.MembersRow newMember = appData.Members.NewMembersRow();

            // Transfer all inputted data into the dataRow
            newMember.MembershipNumber = txtMembershipNumber.Text;
            newMember.Name = txtName.Text;
            newMember.Surname = txtSurname.Text;
            newMember.ContactNumber = txtContact.Text;
            newMember.IDNumber = txtIDNumber.Text;
            newMember.EmailAddress = txtEmail.Text;
            newMember.Province = txtProvince.Text;
            newMember.ServiceSector = txtServiceSection.Text;
            newMember.Gender = gender;

            // Set the amount paid to default of 0
            newMember.AmountPaid = 0;

            // Add the created dataRow to the 'Members' table
            this.appData.Members.Rows.Add(newMember);

            // Update the 'appData.Members' table to update our dataGridView and save the updated table
            try
            {
                this.membersTableAdapter.Update(this.appData.Members);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Enable the row for editting and deleting
            txtName.Enabled = true;
            txtSurname.Enabled = true;
            txtIDNumber.Enabled = true;
            txtContact.Enabled = true;
            txtEmail.Enabled = true;
            txtProvince.Enabled = true;
            txtServiceSection.Enabled = true;
            txtMembershipNumber.Enabled = true;
            radMale.Enabled = true;
            radFemale.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = true;
            btnRemove.Enabled = true;
            panel2.Enabled = true;
            txtAmountPaid.Enabled = true;
            btnAdd.Enabled = true;

            // Set focus on the Name textbox
            txtName.Focus();

            // Get the selected index of the table
            index = dataGridView1.CurrentCell.RowIndex;

            //Show the members details
            txtMembershipNumber.Text = this.appData.Members.Rows[index].ItemArray[0].ToString();
            txtName.Text = this.appData.Members.Rows[index].ItemArray[1].ToString();
            txtSurname.Text = this.appData.Members.Rows[index].ItemArray[2].ToString();
            txtContact.Text = this.appData.Members.Rows[index].ItemArray[3].ToString();
            txtIDNumber.Text = this.appData.Members.Rows[index].ItemArray[4].ToString();
            txtEmail.Text = this.appData.Members.Rows[index].ItemArray[5].ToString();
            txtProvince.Text = this.appData.Members.Rows[index].ItemArray[6].ToString();
            txtServiceSection.Text = this.appData.Members.Rows[index].ItemArray[7].ToString();
            if (this.appData.Members.Rows[index].ItemArray[8].ToString() == "Male") { radMale.Checked = true; }
            else { radFemale.Checked = true; }
            amount = int.Parse(this.appData.Members.Rows[index].ItemArray[9].ToString());

            // Display Amount slip
;            rxtOut.Text = $"{txtName.Text} {txtSurname.Text} - {txtMembershipNumber.Text}\n";
            rxtOut.Text += "-----------------------------------------------------------------------\n";
            rxtOut.Text += $"Current Balance: \t\t\t {amount.ToString()}\n";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Disable the necessary inputs and buttons
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtIDNumber.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtProvince.Enabled = false;
            txtServiceSection.Enabled = false;
            txtMembershipNumber.Enabled = false;
            radMale.Enabled = false;
            radFemale.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;

            // Save all editted information back the database
            this.appData.Members[index].MembershipNumber = txtMembershipNumber.Text;
            this.appData.Members[index].Name = txtName.Text;
            this.appData.Members[index].Surname = txtSurname.Text;
            this.appData.Members[index].ContactNumber = txtContact.Text;
            this.appData.Members[index].IDNumber = txtIDNumber.Text;
            this.appData.Members[index].EmailAddress = txtEmail.Text;
            this.appData.Members[index].Province = txtProvince.Text;
            this.appData.Members[index].ServiceSector = txtServiceSection.Text;
            this.appData.Members[index].Gender = gender;
            
            // Update the table again to refresh the dataGridView and save to access database
            try
            {
                this.membersTableAdapter.Update(this.appData.Members);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Prompt the user before deleting any records
            if (MessageBox.Show("Are you sure you want to delete this?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Delete the selected row from the data table
                this.appData.Members.Rows[index].Delete();

                // Update the table again to refresh the dataGridView and save to access database
                try
                {
                    this.membersTableAdapter.Update(this.appData.Members);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Disable all inputs and buttons
                txtName.Enabled = false;
                txtSurname.Enabled = false;
                txtIDNumber.Enabled = false;
                txtContact.Enabled = false;
                txtEmail.Enabled = false;
                txtProvince.Enabled = false;
                txtServiceSection.Enabled = false;
                txtMembershipNumber.Enabled = false;
                radMale.Enabled = false;
                radFemale.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                // Clear all input fields
                txtName.Clear();
                txtSurname.Clear();
                txtIDNumber.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                txtProvince.Clear();
                txtServiceSection.Clear();
                txtMembershipNumber.Clear();
                rxtOut.Clear();
                radMale.Checked = false;
                radFemale.Checked = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Establish a query that will sdisplay the whole table by default
            var query = from o in this.appData.Members select o;

            // As long as the search box is not empty conduct query search according to filter
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                switch (filter)
                {
                    case "Membership Number":
                        query = from o in this.appData.Members where o.MembershipNumber.Contains(txtSearch.Text) select o;
                        break;
                    case "Name":
                        query = from o in this.appData.Members where o.Name.Contains(txtSearch.Text) select o;
                        break;
                    case "Surname":
                        query = from o in this.appData.Members where o.Surname.Contains(txtSearch.Text) select o;
                        break;
                    case "ID Number":
                        query = from o in this.appData.Members where o.IDNumber.Contains(txtSearch.Text) select o;
                        break;
                    case "Province":
                        query = from o in this.appData.Members where o.Province.Contains(txtSearch.Text) select o;
                        break;
                    case "Service Sector":
                        query = from o in this.appData.Members where o.ServiceSector.Contains(txtSearch.Text) select o;
                        break;
                    case "Gender":
                        query = from o in this.appData.Members where o.Gender.Contains(txtSearch.Text) select o;
                        break;
                    case "Amount Paid":
                        query = from o in this.appData.Members where o.AmountPaid.Equals(txtSearch.Text) select o;
                        break;
                    case "Default":
                        query = from o in this.appData.Members select o;
                        break;
                }

                // Update the dataGridView to the queried selection
                dataGridView1.DataSource = query.ToList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Disable all inputs and buttons
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtIDNumber.Enabled = false;
            txtContact.Enabled = false;
            txtEmail.Enabled = false;
            txtProvince.Enabled = false;
            txtServiceSection.Enabled = false;
            txtMembershipNumber.Enabled = false;
            radMale.Enabled = false;
            radFemale.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            // Clear all input fields
            txtName.Clear();
            txtSurname.Clear();
            txtIDNumber.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtProvince.Clear();
            txtServiceSection.Clear();
            txtMembershipNumber.Clear();
            radMale.Checked = false;
            radFemale.Checked = false;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set global filter variable to selected option
            filter = cmbFilter.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Disable the following to prevent changes and errors occurring
            txtAmountPaid.Enabled = false;
            btnAdd.Enabled = false;

            // Add the amount specified to the current members balance and then update value in the table
            amount += int.Parse(txtAmountPaid.Text);
            this.appData.Members[index].AmountPaid = amount;

            rxtOut.Text += $"Amount Paid: \t\t\t {txtAmountPaid.Text}\n";
            rxtOut.Text += $"New Balance: \t\t\t {amount.ToString()}\n";

            // Update appData to refresh DataGridView and save to access database
            try
            {
                this.membersTableAdapter.Update(this.appData.Members);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Clear the amount paid textbox
            txtAmountPaid.Clear();
        }
    }
}
