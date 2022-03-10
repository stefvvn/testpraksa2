using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook.Business;
using Facebook.Data.EntityFramework;
using Facebook.Entities;

namespace Facebook.UI.Winform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //INSERT
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to insert the entered user data?", "Insert User", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            AccountUserInfoBsn bsn = new AccountUserInfoBsn();
            AccountUserInfoEntities user = new AccountUserInfoEntities();
            user.UserName = textBox1.Text;
            user.FirstName = textBox2.Text;
            user.LastName = textBox3.Text;
            user.EmailAddress = textBox4.Text;
            user.City = textBox5.Text;
            user.Gender = byte.Parse(textBox6.Text);
            user.DateOfBirth = DateTime.Parse(dateTimePicker1.Text);
            user.ProfileDescription = textBox8.Text;
            bsn.InsertUser(user);
        }

        //SEARCH
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text)) 
            {
                List<AccountUserInfoEntities> users = new List<AccountUserInfoEntities>();
                AccountUserInfoBsn bsn = new AccountUserInfoBsn();
                users = bsn.GetUsersMultiParam(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString());
                dataGridView1.DataSource = users;
            }
            else
            {
                List<AccountUserInfoEntities> user = new List<AccountUserInfoEntities>();
                AccountUserInfoBsn bsn = new AccountUserInfoBsn();
                user = bsn.GetUserById(int.Parse(textBox9.Text));
                dataGridView1.DataSource = user;
            }
        }

        //DELETE
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected user?", "Delete User", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            AccountUserInfoBsn bsn = new AccountUserInfoBsn();
            AccountUserInfoEntities user = bsn.DeleteUserByID(int.Parse(textBox9.Text));
        }

        //UPDATE
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the entered user data?", "Update User", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            AccountUserInfoBsn bsn = new AccountUserInfoBsn();
            AccountUserInfoEntities user = bsn.GetUserByID(int.Parse(textBox9.Text));
            AccountUserInfoEntities user1 = bsn.UpdateUserAccountInfo(user);
            user1.UserName = textBox1.Text;
            user1.FirstName = textBox2.Text;
            user1.LastName = textBox3.Text;
            user1.EmailAddress = textBox4.Text;
            user1.City = textBox5.Text;
            user1.Gender = byte.Parse(textBox6.Text);
            user1.DateOfBirth = DateTime.Parse(dateTimePicker1.Text);
            user1.ProfileDescription = textBox8.Text;
            bsn.UpdateUserAccountInfo(user);
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
