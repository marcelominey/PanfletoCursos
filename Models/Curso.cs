using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanfletoCursos.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int IdCurso { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=1)]
        public int IdArea { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=2)]
        public string NomeCurso { get; set; }

        public Area Area { get; set; }

        public ICollection<Turma> Turma { get; set; }

    }
}