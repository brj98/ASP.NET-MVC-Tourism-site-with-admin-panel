﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPRO.Models.Class
{
    public class Restoranlar
    {
        [Key]

        public int ID { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
    }
}