using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PanfletoCursos.Dados;
using PanfletoCursos.Models;

namespace PanfletoCursos.Controllers
{

    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        Curso curso = new Curso();
        readonly PanfletoContexto contexto; //não quero que contexto tenha nenhum valor associado, por isso o readonly

        public CursoController(PanfletoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Curso> Listar(){
            return contexto.Curso.ToList();
            //Esse DbSet é Banco de dados virtual tipado com Curso
            //Esse é o Get.
            //ToList: listando todo mundo
        }
        [HttpGet("{id}")]
        public Curso Listar(int id){
            return contexto.Curso.Where(x=>x.IdCurso==id).FirstOrDefault();
            //Buscando uma área específica
        }
        [HttpPost]
        public void Cadastrar([FromBody] Curso curcu){
            //Usando Entity Framework, só adiciona e salva.
            //Não precisa daquele INSERT INTO... etc
            contexto.Curso.Add(curcu);
            contexto.SaveChanges();
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Curso curso){
            if(curso==null || curso.IdCurso!=id){
                return BadRequest();
            }
            var cur = contexto.Curso.FirstOrDefault(x=>x.IdCurso==id);
            if(cur==null)
            return NotFound();

            cur.IdCurso = curso.IdCurso;
            cur.NomeCurso = curso.NomeCurso;

            contexto.Curso.Update(cur);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var curcu = contexto.Curso.Where(x=>x.IdCurso==id).FirstOrDefault();
            if(curcu == null){
                return NotFound();
            }
            contexto.Curso.Remove(curso);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }
    } 
}