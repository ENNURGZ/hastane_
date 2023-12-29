using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İsim giriniz.")]
        [MinLength(0, ErrorMessage = "İsim giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim giriniz.")]
        [MinLength(0, ErrorMessage = "Soyisim giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Geçersiz.")]
        [StringLength(30, ErrorMessage = "Kullanıcı Adı En Fazla 30 Karakter Olabilir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Eşleşmiyor.")]
        [MinLength(3, ErrorMessage = "Şifre En Az 3 Karakter Olmalıdır.")]
        [MaxLength(16, ErrorMessage = "Şifre En Fazla 16 Karakter Olabilir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Eşleşmiyor.")]
        [MinLength(3, ErrorMessage = "Şifre En Az 3 Karakter Olmalıdır.")]
        [MaxLength(16, ErrorMessage = "Şifre En Fazla 16 Karakter Olabilir.")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
} 
