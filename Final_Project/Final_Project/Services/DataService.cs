using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Final_Project.Services.Interfaces;
using Final_Project.Entities;
using Final_Project.Users;
using Final_Project.Utilities.Enums;

namespace Final_Project.Services
{
    public class DataService: IDataService
    {
        private Dictionary<Guid, UserEntity> _userTable;
        private Dictionary<Guid, ApplicantEntity> _applicantTable;
        private Dictionary<Guid, ApplicantEntity> _acceptedApplicantsTable;

        private List<UserEntity> users;
        private List<ApplicantEntity> applicants;
        private List<ApplicantEntity> acceptedApplicants;
        private Dictionary<string, string> _passwords;
        public DataService()
        {

            _userTable = new Dictionary<Guid, UserEntity>();
            _applicantTable  = new Dictionary<Guid, ApplicantEntity>();
             users = new List<UserEntity>();
            applicants = new List<ApplicantEntity>();
            _passwords = new Dictionary<string, string>();
            acceptedApplicants =  new List<ApplicantEntity>();
            _acceptedApplicantsTable = new Dictionary<Guid, ApplicantEntity>();

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Services/Data/applicantdata.csv");
            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(',');
                    ApplicantEntity applicant = new ApplicantEntity
                    {
                        id = Guid.NewGuid(),
                        FirstName = values[0],
                        LastName = values[1],
                        Email = values[2],
                        PhoneNumber = values[3],
                        Address = values[4],
                        JobPosition = (JobTypeEnum)Int32.Parse(values[5]),
                        ResumeUrl = values[6],
                        LinkedInUrl = values[7],
                        PortifolioUrl = values[8],
                        AcceptedByRecuriter = false,
                        AcceptedByManager = false
                    };

                    _applicantTable.Add(applicant.id, applicant);
                    applicants.Add(applicant);
                }
            }

            string filePathPasswords = Path.Combine(Directory.GetCurrentDirectory(), "../../../Services/Data/userdata.csv");
            using (var reader = new StreamReader(filePathPasswords))
            {
                var line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(',');

                    UserEntity user = new UserEntity
                    {
                        id = Guid.NewGuid(),
                        FirstName = values[0],
                        LastName = values[1],
                        Email = values[2],
                        username = values[3],
                        password = values[4],
                        Recuriter = Boolean.Parse(values[5])

                     
                    };

                    _userTable.Add(user.id, user);
                    users.Add(user);
                    _passwords.Add(user.username, user.password);
                }
            }


            string filePathAcceptedApplicants = Path.Combine(Directory.GetCurrentDirectory(), "../../../Services/Data/acceptedapplicantsdata.csv");
            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(',');
                    ApplicantEntity applicant = new ApplicantEntity
                    {
                        id = Guid.NewGuid(),
                        FirstName = values[0],
                        LastName = values[1],
                        Email = values[2],
                        PhoneNumber = values[3],
                        Address = values[4],
                        JobPosition = (JobTypeEnum)Int32.Parse(values[5]),
                        ResumeUrl = values[6],
                        LinkedInUrl = values[7],
                        PortifolioUrl = values[8],
                        AcceptedByRecuriter = false,
                        AcceptedByManager = false
                    };
                    _acceptedApplicantsTable.Add(applicant.id, applicant);
                    acceptedApplicants.Add(applicant);
                }
            }
        }

        public UserEntity getUser(Guid userId)
        {
         
                return _userTable[userId];
           
        }

        public ApplicantEntity getApplicant(Guid applicantId)
        {
            return _applicantTable[applicantId];

        }

        public void updateApplicant(ApplicantEntity applicant)
        {
            applicants.Remove(_applicantTable[applicant.id]);
            applicants.Add(applicant);
            _applicantTable[applicant.id] = applicant;
            
        }
        public void acceptApplicant(Guid applicantId)
        {
            _acceptedApplicantsTable.Add(applicantId, _applicantTable[applicantId]);
            acceptedApplicants.Add(_applicantTable[applicantId]);
            deleteApplicant(applicantId);

        }
        public void deleteApplicant(Guid applicantId)
        {

            applicants.Remove(_applicantTable[applicantId]);
            _applicantTable.Remove(applicantId);

            //remove from csv file
        }

        public List<ApplicantEntity> search(string fname, string lname, JobTypeEnum job)
        {
           
            var applicantList = (from applicant in applicants
                                where applicant.FirstName.Contains(fname) && applicant.LastName.Contains(lname) && applicant.JobPosition == job
                                select applicant).ToList();
            return applicantList;
        }

        public Guid login(string username, string password) 
        {
            if ( _passwords.ContainsKey(username) && _passwords[username] == password)
            {
                var user = (from u in users
                           where u.username == username && u.password == password
                           select u).First();
                return user.id;
            }

            return new Guid();
            //throw exception?

        }
    }
}
