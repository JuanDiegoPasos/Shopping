using System.ComponentModel.DataAnnotations;

namespace Shopping.DAL.Entities
{
    public class AuditBase
    {
        [Key] //pk
        [Required] //obligatorio
        public virtual Guid Id { get; set;  } //generar clave Pk de todas las tablas
        public virtual DateTime? CreatedDate { get; set; } //guardar fecha de creacion

        public virtual DateTime? ModifiedDate { get; set; } //guardar fecha de modificacion

    }
}
