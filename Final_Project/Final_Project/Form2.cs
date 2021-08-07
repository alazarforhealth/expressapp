using Final_Project.Services.Interfaces;
using Final_Project.Users;
using Final_Project.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form2 : Form
    {
        private User _user;
        private IDataService _service;
        public Form2(User user, IDataService service)
        {
            _user = user;
            _service = service;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = _user.getName();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var applicants = _service.search(fname.Text, lname.Text, (JobTypeEnum) jobType.SelectedIndex);
            Form3 f = new Form3(_user, _service, applicants);
            f.ShowDialog();
        }

    }
}
