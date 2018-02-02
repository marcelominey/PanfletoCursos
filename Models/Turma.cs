using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanfletoCursos.Models
{
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int IdTurma { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=1)]
        public int IdCurso { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=2)]
        public DateTime DataInicial { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=3)]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=4)]
        public string DiasSemana { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=5)]
        public DateTime HorarioInicial { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório")]
        [Column(Order=6)]
        public DateTime HorarioFinal { get; set; }

        public Curso Curso { get; set; }

        
                        
    }
}