using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class RegisterViewModel
    {
        //[Display(Name ="Kullanıcı Adı", Prompt ="johndoe")]
        [Required(ErrorMessage = "Kullanıcı Adı Geçersiz.")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters.")]
        public string Username { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Eşleşmiyor.")]
        [MinLength(6, ErrorMessage = "Şifre En Az 6 Karakter Olmalıdır.")]
        [MaxLength(16, ErrorMessage = "Şifre En Fazla 16 Karakter Olabilir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Eşleşmiyor.")]
        [MinLength(6, ErrorMessage = "Şifre En Az 6 Karakter Olmalıdır.")]
        [MaxLength(16, ErrorMessage = "Şifre En Fazla 16 Karakter Olabilir.")]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
