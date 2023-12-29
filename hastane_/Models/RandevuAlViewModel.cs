// RandevuAlViewModel.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class RandevuAlViewModel
    {
        [Required(ErrorMessage = "Randevu günü zorunludur.")]
        [Display(Name = "Randevu Günü")]
        public DateTime RandevuGunu { get; set; }

        [Required(ErrorMessage = "Randevu saati zorunludur.")]
        [Display(Name = "Randevu Saati")]
        public TimeSpan RandevuSaati { get; set; }

        [Required(ErrorMessage = "Doktor seçimi zorunludur.")]
        [Display(Name = "Doktor")]
        public Guid DoctorId { get; set; }

        public Guid UserId { get; set; }

        public int PoliklinikId { get; set; }


    }
}