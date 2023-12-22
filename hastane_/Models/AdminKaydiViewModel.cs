﻿using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class AdminKaydiViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(0, ErrorMessage = "İsim giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [MinLength(0, ErrorMessage = "Soyisim giriniz.")]
        public string Surname { get; set; }

        //[Display(Name ="Kullanıcı Adı", Prompt ="johndoe")]
        [Required(ErrorMessage = "Kullanıcı Adı Geçersiz.")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters.")]
        public string Username { get; set; }

        //[DataType(DataType.Password)]
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
