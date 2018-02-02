using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PanfletoCursos.Dados;
using PanfletoCursos.Models;

namespace PanfletoCursos.Controllers
{

    [Route("api/[controller]")]
    public class TurmaController : Controller
    {
        Turma turma = new Turma();
        readonly PanfletoContexto contexto; //não quero que contexto tenha nenhum valor associado, por isso o readonly

        public TurmaController(PanfletoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Turma> Listar(){
            return contexto.Turma.ToList();
            //Esse DbSet é Banco de dados virtual tipado com Area
            //Esse é o Get.
            //ToList: listando todo mundo
        }
        [HttpGet("{id}")]
        public Turma Listar(int id){
            return contexto.Turma.Where(x=>x.IdTurma==id).FirstOrDefault();
            //Buscando uma área específica
        }
        [HttpPost]
        public void Cadastrar([FromBody] Turma turtu){
            //Usando Entity Framework, só adiciona e salva.
            //Não precisa daquele INSERT INTO... etc
            contexto.Turma.Add(turtu);
            contexto.SaveChanges();
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Turma turma){
            if(turma==null || turma.IdTurma!=id){
                return BadRequest();
            }
            var tur = contexto.Turma.FirstOrDefault(x=>x.IdTurma==id);
            if(tur==null)
            return NotFound();

            tur.IdTurma = tur.IdTurma;
            tur.DataInicial = tur.DataInicial;
            tur.DataFinal = tur.DataFinal;
            tur.DiasSemana = tur.DiasSemana;
            tur.HorarioInicial = tur.HorarioInicial;
            tur.HorarioFinal = tur.HorarioFinal;            

            contexto.Turma.Update(tur);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var turtu = contexto.Turma.Where(x=>x.IdTurma==id).FirstOrDefault();
            if(turtu == null){
                return NotFound();
            }
            contexto.Turma.Remove(turma);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }
    }
}