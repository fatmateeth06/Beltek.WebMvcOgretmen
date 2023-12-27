using System.ComponentModel.DataAnnotations;

namespace Beltek.WebMvc.Models
{
    public class Ogretmen
    {
        [Key]
        public string TcKimlik { get; set; }//id yap otomatik primary key ve id yapmayı öğren
        
        public string Ad  { get; set; }
        public string Soyad { get; set; }
        public string Alan { get; set; }//yeni dbset yeni fluent api en son add-migration-updatedatabase tckimlik primary key id crud işlemleri view ile yap
                                        ////ad student add teacher..
    }
}
