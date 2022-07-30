using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class Сотрудник
    {
        [Key]
        public int Шифр { get; set; }
        public string ФИО { get; set; }
        public string  Дата_рождения { get; set; }
        public string Пол { get; set; }
    }
}