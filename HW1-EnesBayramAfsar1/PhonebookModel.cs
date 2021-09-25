using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HW1_EnesBayramAfsar1
{
    public class PhonebookModel
    {
        [Required]
        public int Id { get; set; }
       
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Karakter sayısını kontrol ediniz!")]
        public string İsim { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Karakter sayısını kontrol ediniz!")]
        public string Soyisim { get; set; }

        [Required]
        [RegularExpression("(E|K)", ErrorMessage = "Erkek için (E), Kadın için (K) giriniz!")]
        public string Cinsiyet { get; set; }

        [RegularExpression("^(0(d{3})-(d{3})-(d{2})-(d{2}))$", ErrorMessage = "Telefon numarasını doğru formatta giriniz!")]
        public string Telefon { get; set; }
        
    }
}
