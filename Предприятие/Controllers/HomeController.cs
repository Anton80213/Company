using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Лабораторная_11.Models;
using System.Windows.Forms;
using System.Data;
using Newtonsoft.Json;

namespace Лабораторная_11.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        static EmployeeContext db = new EmployeeContext();
        public string Home()
        {
            return null;
        }
        public ActionResult Index()
        {
            Model_College model = new Model_College()
            {
                сотрудники = db.Сотрудники.ToList(),
                сотрудники2 = db.Сотрудники2.ToList(),
                должности = db.Должности.ToList()
            };
            
            return View(model);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Сотрудник сотрудник)
        {
            var Запрос = from x in db.Сотрудники
                         where x.Шифр == сотрудник.Шифр
                         group x by x.Шифр into g
                         select g.Count();
            foreach (var i in Запрос)
            {
                if (i > 0)
                {
                    MessageBox.Show("Ошибка: сотрудник с данным шифром уже существует");
                    return RedirectToAction("Create");
                }
            }
            db.Сотрудники.Add(сотрудник);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create2(Сотрудник2 сотрудник2)
        {
            var Запрос2 = from x in db.Сотрудники2
                         where x.Шифр == сотрудник2.Шифр 
                         group x by x.Шифр into g
                         select g.Count();
            foreach (var i in Запрос2)
            {
                if (i > 2) MessageBox.Show("Трудовой опыт данного сотрудника - более 2 специальностей");
            }
            db.Сотрудники2.Add(сотрудник2);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create3(Должность должность)
        {
            db.Должности.Add(должность);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Выборка_данных1()
        {
            var query = from x in db.Сотрудники2.AsEnumerable()
                        where x.Должность == "Инженер"
                        group x by x.Шифр into g
                        join y in db.Сотрудники.AsEnumerable()
                        on g.FirstOrDefault().Шифр equals y.Шифр
                        select y; // запрос, выводящий информацию о сотруднике из таблицы "Сотрудники", который работал (работает) по специальности "Инженер"
            return View(query);
        }
        [HttpGet]
        public ActionResult Выборка_данных2()
        {
            var query = from x in db.Должности.AsEnumerable()
                        join y in db.Сотрудники2.AsEnumerable()
                        on x.Название equals y.Должность
                        where y.Шифр == 1 && y.Дата_увольнения == "-"
                        group new { x, y } by y.Шифр into g
                        from h in g
                        select new Model1{ Шифр = g.Key, Должность = h.y.Должность, Зарплата = h.y.Зарплата, Дата_принятия = h.y.Дата_принятия };
                        // 
            return View(query);
        }
        [HttpGet]
        public ActionResult Выборка_данных3()
        {
            DateTime date1 = new DateTime(1990, 01, 01);
            DateTime date2 = new DateTime(1995, 01, 01);
            var query = from x in db.Сотрудники2.AsEnumerable()
                        where DateTime.Compare(date1, new DateTime(int.Parse(x.Дата_принятия.Substring(6)), int.Parse(x.Дата_принятия.Substring(3, 2)), int.Parse(x.Дата_принятия.Substring(0, 2)))) < 0 && DateTime.Compare(date2, new DateTime(int.Parse(x.Дата_принятия.Substring(6)), int.Parse(x.Дата_принятия.Substring(3, 2)), int.Parse(x.Дата_принятия.Substring(0, 2)))) > 0
                        group x by x.Шифр into g
                        join y in db.Сотрудники.AsEnumerable()
                        on g.FirstOrDefault().Шифр equals y.Шифр
                        select y;
            return View(query);
        }
        [HttpGet]
        public ActionResult Выборка_данных4()
        {
            var query =  from x in db.Сотрудники2.AsEnumerable()
                     join y in db.Должности.AsEnumerable()
                     on x.Должность equals y.Название
                     group new { x, y } by y.Название into g
                     select new Model2{ Должность = g.Key, Максимальная_зарплата = g.Max(h => h.x.Зарплата), Минимальная_зарплата = g.Min(h => h.x.Зарплата) };
            return View(query);
        }
        
    }
}