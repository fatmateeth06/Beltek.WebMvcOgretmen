
using Beltek.WebMvc.Models;
using Beltek.WebMvc.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Beltek.WebMvc.Controllers
{
    public class OgrenciController : Controller
    {//url routing
        public ViewResult Index()//Action Metod
        {
            return View();
        }
        public ViewResult OgrenciEkle()
        {
            return View("AddStudent");
        }
        public ViewResult OgrenciDetay(int Id)
        {
            Ogrenci ogrenci = null;
            Ogretmen ogretmen = null;
            if (Id == 1)
            {
                ogrenci = new Ogrenci(1, "Ali", "Veli");
                ogretmen = new Ogretmen { Ad = "Osman", Soyad = "Yıldız", Alan = "matematik" };
            }
            else if (Id == 2)
            {
                ogrenci = new Ogrenci(2, "Ahmet", " Mehmet");
                ogretmen = new Ogretmen {  Ad = "Veysel", Soyad = "Yılmaz", Alan = "Türkçe" };
            }
            //if (ogrenci != null)//null check:Referans tipi verilerde dikkat edilmesi gerekir.
            //{
            //    return $"Adı:{ogrenci.Ad} Soyadı:{ogrenci.Soyad} Id:{ogrenci.Id}";
            //}
            //else
            //{
            //    return "Öğrenci Bulunamadı!";
            //}m

            ViewData["ogr"] = ogrenci;//tek view data ismi yazılır birden fazla isim yazılmaz
            ViewBag.student = ogrenci;

            var dto = new OgrenciDTO();
            dto.Teacher = ogretmen;
            dto.Student = ogrenci;

            return View(dto);
        }

        public ViewResult OgrenciListe()
        {
            var ogr = new Ogrenci(1, "Ahmet", "Soyad");
            var ogr1 = new Ogrenci(2, "Ali", "Veli");

            Ogrenci[] ogrenciler = new Ogrenci[2];
            ogrenciler[0] = ogr;
            ogrenciler[1] = ogr1;

            ViewData["Students"] = ogrenciler;
            ViewBag.ogrenciler = ogrenciler;
            //view bag arka planda viewdata kullanıyor o yüzden aynı isimde olmamalı.

            return View(ogrenciler);
        }
        public ViewResult StudentList()
        {
            var ogr = new Ogrenci(1, "Ahmet", "Soyad");
            var ogr1 = new Ogrenci(2, "fatma", "Disli");
            List<Ogrenci> lst = new List<Ogrenci> { ogr, ogr1 };

            return View(lst);
        }
    }



}
//controller:istekleri karşılayan yapılar,
//tarayıcı csdan anlamaz render yaparak htmle dönüştürür
//controller'dan view'e veri taşıma 
//viewData:key- value çiftlerinden oluşan bir koleksiyondur.keylerin veri tipleri string ,valuelerin veri tipleri objectir
//viewBag:viewdata ile aynı key-value koleksiyonu kullanır.bu nedenle key'ler verilirken dikkat edilmelidir.
//viewModel;:Controllerdan view'e View() methodu aracılığı ile veri taşıma .View() metoduna gönderilen veri,View tarafında
//@model ifadesi ile karşılandıktan sonra ,view içerisinde istenilen yerde @model ifadesi ile ulaşılarak kullanılabilir.Bu yöntemle taşınan verilerde object tipindedir.

//DTO: Data Transfer Object :Birden fazla veri tipinde olan değerleri modellemek amacıyla kullanılan classlardır.
//program cs:pattern
//dto birden fazla entity varlık vardır