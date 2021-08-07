using Final_Project.Entities;
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
    public partial class Form3 : Form
    {
        private User _user;
        private IDataService _service;
        IEnumerable<ApplicantEntity> _applicants;
        List<Guid> _listValues;
        public Form3(User user, IDataService service, IEnumerable<ApplicantEntity> applicants)
        {
            _user = user;
            _service = service;
            _applicants = applicants;
            _listValues = new List<Guid>();
            InitializeComponent();
            label1.Text = _user.getName();


            foreach (var applicant in _applicants) 
            {
                ListViewItem item = new ListViewItem(applicant.id.ToString());
                item.SubItems.Add(applicant.FirstName);
                item.SubItems.Add(applicant.LastName);
                item.SubItems.Add(applicant.JobPosition.ToString());
                item.SubItems.Add(applicant.Email);
                listView1.Items.Add(item);
                _listValues.Add(applicant.id);

            } 
        }

        private void search_Click(object sender, EventArgs e)
        {

            _applicants = _service.search(fname.Text, lname.Text, (JobTypeEnum)jobType.SelectedIndex);
            // same thing as above
            listView1.Items.Clear();
            _listValues.Clear();

            foreach (var applicant in _applicants)
            {
                ListViewItem item = new ListViewItem(applicant.id.ToString());
                item.SubItems.Add(applicant.FirstName);
                item.SubItems.Add(applicant.LastName);
                item.SubItems.Add(applicant.JobPosition.ToString());
                item.SubItems.Add(applicant.Email);

                listView1.Items.Add(item);
                _listValues.Add(applicant.id);
            }

        }


      
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var rectangle = listView1.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    
                    Form4 form = new Form4(_user,_service.getApplicant(_listValues[i]) , _service);
                    form.ShowDialog();
                    
                }
            }
        }
    }
}
