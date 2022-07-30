using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Лабораторная_11.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Сотрудник> Сотрудники { get; set; }
        public DbSet<Должность> Должности { get; set; }
        public DbSet<Сотрудник2> Сотрудники2 { get; set; }
        public DbSet<Model1> Models1 { get; set; }
        public DbSet<Model2> Models2 { get; set; }
    }
}