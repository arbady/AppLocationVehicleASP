using AppLocationVehicleASP.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Models.Forms
{
    public class UserForm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [MaxLength(50, ErrorMessage = "Le champs doit faire au max 50 caractères")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [MaxLength(50, ErrorMessage = "Le champs doit faire au max 50 caractères")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [EnumDataType(typeof(Sex), ErrorMessage = "Veillez choisir correctement le sexe")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [MaxLength(255, ErrorMessage = "Le champs doit faire au max 50 caractères")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [MaxLength(9, ErrorMessage = "Votre mot de passe doit contenir au minimum 9 caractères")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [Compare("Password", ErrorMessage = "Vos mots de passe ne correspondent pas")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public string Address { get; set; }

        //[Required]
        public string Phone { get; set; }

        [Required]
        public Role Role { get; set; }
        //public string Token { get; set; }

    }
}
