using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PanfletoCursos.Dados;
using PanfletoCursos.Models;

namespace PanfletoCursos.Controllers
{

    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        Area area = new Area();
        readonly PanfletoContexto contexto; //não quero que contexto tenha nenhum valor associado, por isso o readonly

        public AreaController(PanfletoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Area> Listar(){
            return contexto.Area.ToList();
            //Esse DbSet é Banco de dados virtual tipado com Area
            //Esse é o Get.
            //ToList: listando todo mundo
        }
        [HttpGet("{id}")]
        public Area Listar(int id){
            return contexto.Area.Where(x=>x.IdArea==id).FirstOrDefault();
            //Buscando uma área específica
        }
        [HttpPost]
        public void Cadastrar([FromBody] Area arere){
            //Usando Entity Framework, só adiciona e salva.
            //Não precisa daquele INSERT INTO... etc
            contexto.Area.Add(arere);
            contexto.SaveChanges();
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Area area){
            if(area==null || area.IdArea!=id){
                return BadRequest();
            }
            var are = contexto.Area.FirstOrDefault(x=>x.IdArea==id);
            if(are==null)
            return NotFound();

            are.IdArea = area.IdArea;
            are.NomeArea = area.NomeArea;

            contexto.Area.Update(are);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }
    } 
}