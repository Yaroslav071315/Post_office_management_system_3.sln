using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_office_management_system_3.Data.Models
{
    public class Parcel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [Required]
        public DateTime DateSend { get; set; }

        [Required]
        public DateTime DateCome { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int PostOfficeSendId { get; set; }

        [ForeignKey("PostOfficeSendId")]
        public PostOffice PostOfficeSend { get; set; }

        public int PostOfficeComeId { get; set; }

        [ForeignKey("PostOfficeComeId")]
        public PostOffice PostOfficeCome { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
