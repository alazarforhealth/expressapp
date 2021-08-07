using Final_Project.Entities;
using Final_Project.Services.Interfaces;
using Final_Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form4 : Form
    {
        ApplicantEntity _applicant;
        IDataService _service;
        User _user;
        
        public Form4(User user, ApplicantEntity applicant, IDataService service)
        {
            _applicant = applicant;
            _service = service;
            _user = user;
            InitializeComponent();
            name.Text = _applicant.FirstName + " " + _applicant.LastName;
            email.Text = _applicant.Email;
            phoneNum.Text = _applicant.PhoneNumber;
            address.Text = _applicant.Address;
            resumeLink.Text = _applicant.ResumeUrl;
            linkedInLink.Text = _applicant.LinkedInUrl;
            portfolioLnk.Text = _applicant.PortifolioUrl;
            jobDescription.Text = _applicant.JobPosition.ToString();
            SSN.Text = _applicant.SSN;
            label1.Text = _user.getName();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(_user, _service);
            f.ShowDialog();
        }

        private void acceptApplicant_Click(object sender, EventArgs e)
        {
            _user.acceptApplicant(_applicant.id);
            this.Close();
        }

        private void rejectApplicant_Click(object sender, EventArgs e)
        {
            _user.rejectApplicant(_applicant.id);
            this.Close();
        }
    }
}
