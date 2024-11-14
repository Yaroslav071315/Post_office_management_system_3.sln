using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;
using Post_office_management_system_3.Data.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Post_office_management_system_3.Forms
{
    public class FormFactory
    {
        private readonly ClientRepository _clientRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly HeadPostOfficeRepository _headPostOfficeRepository;
        private readonly PostOfficeDbContext _dbContext;
        private readonly PostOfficeRepository _postOfficeRepository;
        private readonly ParcelRepository _parcelRepository;
        public int _clientId;

        public FormFactory()
        {
            // Initialize the DbContext and repositories
            _dbContext = new PostOfficeDbContext(new DbContextOptions<PostOfficeDbContext>());
            _clientRepository = new ClientRepository(_dbContext);
            _employeeRepository = new EmployeeRepository(_dbContext);
            _headPostOfficeRepository = new HeadPostOfficeRepository(_dbContext);
            _postOfficeRepository = new PostOfficeRepository(_dbContext);
            _parcelRepository = new ParcelRepository(_dbContext);
        }

        public Window CreateForm(FormType formType)
        {
            switch (formType)
            {
                case FormType.SignIn:
                    return new SignInForm(_clientRepository, _employeeRepository, _headPostOfficeRepository);
                //case FormType.SignUp:
                //    return new SignUpForm(_clientRepository, _employeeRepository, _headPostOfficeRepository);
                case FormType.ClientForm:
                    return new ClientForm(  _parcelRepository , _postOfficeRepository);
                case FormType.EmployeeForm:
                    return new EmployeeForm(_clientRepository, _parcelRepository);
                case FormType.HeadPostOfficeForm:
                    return new HeadPostOfficeForm(_headPostOfficeRepository,_employeeRepository);
                default:
                    throw new ArgumentException("Invalid form type specified");
            }
        }
    }
}
