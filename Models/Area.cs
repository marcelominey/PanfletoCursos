using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanfletoCursos.Models
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int IdArea { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=1)]
        public string NomeArea { get; set; }
        
        public ICollection<Curso> Curso { get; set; }
    }
}