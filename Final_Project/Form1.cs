using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Services.Interfaces;
using Final_Project.Users;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        private IDataService _service;
        public Form1(IDataService service)
        {

            _service = service;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {

            var userId = _service.login(userName.Text, password.Text);
            if (userId != new Guid())
            {
                var userInfo = _service.getUser(userId);

                User user;
                if (userInfo.Recuriter)
                {
                    user = new Recuriter(userInfo, _service);
                }
                else
                {
                    user = new Manager(userInfo, _service);
                }

                Form2 f = new Form2(user, _service);
                f.ShowDialog();
            }

    
           
        }
    }
}
