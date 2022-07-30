using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class Должность
    {
        [Key]
        public string Название { get; set; } 
        public int Базовый_оклад { get; set; }
    }
}