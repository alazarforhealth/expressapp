using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Final_Project.Services.Interfaces;
using Final_Project.Services;

namespace Final_Project
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        //create HashTable of applicant ids and Applicants
        //create HashTbale of User ids  and Users
        static void Main()
        {
            IDataService service = new DataService();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(service));  // form runs here
        }
    }
}
