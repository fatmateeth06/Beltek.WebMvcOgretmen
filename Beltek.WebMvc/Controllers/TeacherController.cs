using Beltek.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beltek.WebMvc.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ListTeacher");
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            
            return View();
        }
        //[HttpPost]
        //public IActionResult AddTeacher(Ogretmen ogt)//Iactionresult redirect.. base'i
        //{
        //    using (var ctx = new OkulDbContext())
        //    {
        //        ctx.Ogretmenler.Add(ogt);
        //        ctx.SaveChanges();
        //    }
        //    return RedirectToAction("ListTeacher");
        //}
        //public IActionResult ListTeacher()
        //{
        //    List<Ogretmen> lst;
        //    using (var ctx = new OkulDbContext())
        //    {
        //        lst = ctx.Ogretmenler.ToList();
        //    }
        //    return View(lst);//burada atama yapılır.

        //}

        //[HttpPost]
        //public IActionResult AddTeacher(Ogretmen ogt)
        //{

        //    if (ModelState.IsValid) // Öğretmen modeli geçerli mi kontrol et
        //    {
        //        using (var ctx = new OkulDbContext())
        //        {
        //            ctx.Ogretmenler.Add(ogt);
        //            ctx.SaveChanges();
        //        }
        //        return RedirectToAction("ListTeacher");
        //    }
        //    // Eğer model geçerli değilse, ekleme sayfasını tekrar göster
        //    return View(ogt);
        //}
        [HttpPost]
        public IActionResult AddTeacher(Ogretmen ogt)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogt);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListTeacher");
            
        }

        //public IActionResult AddTeacher(Ogretmen ogt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var ctx = new OkulDbContext())
        //        {
        //            ctx.Ogretmenler.Add(ogt);
        //            ctx.SaveChanges();
        //        }
        //        return RedirectToAction("ListTeacher");
        //    }
        //    else
        //    {
        //        // Model geçerli değilse, hata mesajlarını yazdır
        //        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        //        {
        //            Console.WriteLine(error.ErrorMessage);
        //        }

        //        // Sayfayı tekrar göster
        //        return View(ogt);
        //    }
        //}


        public IActionResult ListTeacher()
        {

            List<Ogretmen> lst;

            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Ogretmenler.ToList();
            }
            return View(lst);
        }
        //public IActionResult ListTeacher()
        //{
        //    List<Ogretmen> ogretmenListesi;
        //    using (var ctx = new OkulDbContext())
        //    {
        //        ogretmenListesi = ctx.Ogretmenler.ToList();
        //    }
        //    return View("ListTeacher", ogretmenListesi);
        //}



        public IActionResult DeleteTeacher(string id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogt = ctx.Ogretmenler.FirstOrDefault(o => o.TcKimlik == id);

                if (ogt != null)
                {
                    ctx.Ogretmenler.Remove(ogt);
                    ctx.SaveChanges();
                    return RedirectToAction("ListTeacher");
                }

                return NotFound("Silinecek öğretmen bulunamadı");
            }
        }
        //public IActionResult DeleteTeacher(string TcKimlik)
        //{
        //    // Debug noktası ekleyin veya Console.WriteLine kullanarak kontrol edin
        //    Console.WriteLine("DeleteTeacher metoduna ulaşıldı.");

        //    using (var ctx = new OkulDbContext())
        //    {
        //        var ogt = ctx.Ogretmenler.Find(TcKimlik);
        //        if (ogt != null)
        //        {
        //            ctx.Ogretmenler.Remove(ogt);
        //            ctx.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("ListTeacher");
        //}




        //public IActionResult DeleteTeacher(string TcKimlik)
        //{
        //    using (var ctx = new OkulDbContext())
        //    {
        //        var ogt = ctx.Ogretmenler.Find(TcKimlik);
        //        ctx.Ogretmenler.Remove(ogt);
        //        ctx.SaveChanges();
        //    }
        //    return RedirectToAction("ListTeacher");
        //}


        public IActionResult UpdateTeacher(string id)
        {
            Ogretmen ogt;
            using (var ctx = new OkulDbContext())
            {
                ogt = ctx.Ogretmenler.FirstOrDefault(o => o.TcKimlik == id);
            }

            if (ogt == null)
            {
                return NotFound("Öğretmen bulunamadı");
            }

            return View(ogt);
        }
        //public IActionResult UpdateTeacher(string TcKimlik)
        //{
        //    Ogretmen ogt;
        //    using (var ctx = new OkulDbContext())
        //    {
        //        ogt = ctx.Ogretmenler.Find(TcKimlik);
        //    }
        //    return View(ogt);


        //}
        //[HttpPost]//yazmak zorundayız submitten sonrası çalışmaz
        //public IActionResult UpdateTeacher(Ogretmen ogt)
        //{
        //    using (var ctx = new OkulDbContext())
        //    {
        //        ctx.Entry(ogt).State = EntityState.Modified;
        //        ctx.SaveChanges();
        //    }
        //    return RedirectToAction("ListTeacher");
        //}

        [HttpPost]
        public IActionResult UpdateTeacher(Ogretmen updatedOgretmen)
        {
            using (var ctx = new OkulDbContext())
            {
                // Veritabanından mevcut varlığı al
                var existingOgretmen = ctx.Ogretmenler.Find(updatedOgretmen.TcKimlik);

                if (existingOgretmen != null)
                {
                    // Mevcut varlığın özelliklerini güncelle
                    ctx.Entry(existingOgretmen).CurrentValues.SetValues(updatedOgretmen);

                    // Varlığı değiştirilmiş olarak işaretle
                    ctx.Entry(existingOgretmen).State = EntityState.Modified;

                    // Değişiklikleri kaydet
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("ListTeacher");
        }

    }

}

