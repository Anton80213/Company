using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class Сотрудник2
    {
        [Key]
        public int ID { get; set; }
        public int Шифр { get; set; }
        public string Должность { get; set; }
        public double Размер_ставки { get; set; }
        public string Дата_принятия { get; set; }
        public string Дата_увольнения { get; set; }
        public string Уволен { get; set; }
        public string Причина_увольнения { get; set; }
        public int Год { get; set; }
        public int Месяц { get; set; }
        public int Зарплата { get; set; }
    }
}