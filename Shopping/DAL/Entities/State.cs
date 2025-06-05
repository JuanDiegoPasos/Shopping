using System.ComponentModel.DataAnnotations;

namespace Shopping.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] //cambiar alias
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //longitud maxima
        public string Name { get; set; }

        // RELACION CON EF CORE

        [Display(Name = "Pais")]
        public Country? Country { get; set; }
        // FK
        [Display(Name = "Id Pais")]
        public Guid CountryId { get; set; }
    }
}
