using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPRO.Models.Class

{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Message { get; set; }

    }
}