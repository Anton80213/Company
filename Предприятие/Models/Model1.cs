using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class Model1
    {
        [Key]
        public int Шифр { get; set; }
        public string Должность { get; set; }
        public int Зарплата { get; set; }
        public string Дата_принятия { get; set; }
    }
}