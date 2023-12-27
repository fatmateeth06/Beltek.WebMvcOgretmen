using Beltek.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Beltek.WebMvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ListStudent");
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)//Iactionresult redirect.. base'i
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListStudent");
        }
        public IActionResult ListStudent()
        {
            List<Ogrenci> lst;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Ogrenciler.ToList();
            }
            return View(lst);//burada atama yapılır.
        }

        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                ctx.Ogrenciler.Remove(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListStudent");
        }


        public IActionResult UpdateStudent(int id)
        {
            Ogrenci ogr;
            using (var ctx = new OkulDbContext())
            {
                ogr = ctx.Ogrenciler.Find(id);
            }
            return View(ogr);
        }
        [HttpPost]//yazmak zorundayız submitten sonrası çalışmaz
        public IActionResult UpdateStudent(Ogrenci ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("ListStudent");
        }
    }

}