using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class Model_College
    {
        public IEnumerable<Сотрудник> сотрудники { get; set; }
        public IEnumerable<Сотрудник2> сотрудники2 { get; set; }
        public IEnumerable<Должность> должности { get; set; }
    }
}