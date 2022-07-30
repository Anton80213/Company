using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class Model2
    {
        [Key]
        public string Должность { get; set; }
        public int Максимальная_зарплата { get; set; }
        public int Минимальная_зарплата { get; set; }
    }
}