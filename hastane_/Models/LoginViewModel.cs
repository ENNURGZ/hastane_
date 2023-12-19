using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Geçersiz.")]
        [StringLength(30, ErrorMessage = "Kullanıcı Adı En Fazla 30 Karakter Olabilir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Geçersiz.")]
        [MinLength(3, ErrorMessage = "Şifre En Az 3 Karakter Olmalıdır.")]
        [MaxLength(16, ErrorMessage = "Şifre En Fazla 16 Karakter Olabilir.")]
        public string Password { get; set; }
    }
} 
