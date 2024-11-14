﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_office_management_system_3.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }

        public int HeadPostOfficeId { get; set; }

        [ForeignKey("HeadPostOfficeId")]
        public HeadPostOffice HeadPostOffice { get; set; }
    }
}
