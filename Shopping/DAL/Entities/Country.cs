using System.ComponentModel.DataAnnotations;

namespace Shopping.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")] //cambiar alias
        [Required(ErrorMessage = "El campo {0} es obligatorio")] 
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //longitud maxima
        public string Name { get; set; }

        [Display(Name = "Estados / Departamentos")]
        public ICollection<State>? States { get ; set; }
    }
}
