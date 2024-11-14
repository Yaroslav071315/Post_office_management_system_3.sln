using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_office_management_system_3.Data.Models
{
    public class HeadPostOffice
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public string Password { get; set; }

        public List<PostOffice> PostOffices { get; set; } = new List<PostOffice>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
