using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPRO.Models.Class
{
    public class Admin
    {
        [Key]

        public int ID { get; set; }
        public string AdiSoyad { get; set; }
        public string Eposta { get; set; }
        public string Kulanciadi { get; set; }
        public string Sifre { get; set; }


    }
}