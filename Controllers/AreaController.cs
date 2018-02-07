using System;
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

        /// <sumary>
        /// Retorna uma lista de áreas
        /// </sumary>
        /// <returns>Lista de áreas</returns>
        /// <response code="200">Retorna uma lista de areas</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Area>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Listar()
        {
            try
            {
                return Ok(contexto.Area.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <sumary>
        /// Retorna uma área pelo seu Id
        /// </sumary>
        /// <returns>Id da área</returns>
        /// <response code="200">Retorna uma área</response>
        /// <response code="400">Ocorreu um erro</response>
        /// <response code="404">Área não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Area), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult Listar(int id)
        {
            try
            {
                Area area = contexto.Area.Where(x => x.IdArea == id).FirstOrDefault();
                //return Ok(contexto.Area.ToList());
                //Buscando uma área específica

                if (area == null)
                {
                    return NotFound("Área não encontrada");
                }
                return Ok(area);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <sumary>
        /// Cadastra uma nova área
        /// </sumary>
        /// <returns>Nova área para registrar</returns>
        /// <remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a area request:
        /// 
        ///     POST /Area
        ///     {
        ///         "nome" : "nome da area"
        ///     }    
        /// </remarks>
        /// <response code="200">Retorna a área cadastrada</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpPost]
        [ProducesResponseType(typeof(Area), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Cadastrar([FromBody] Area arere)
        {
            //Usando Entity Framework, só adiciona e salva.
            //Não precisa daquele INSERT INTO... etc
            try{
                contexto.Area.Add(arere);
                contexto.SaveChanges();
                return Ok(arere);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Area area)
        {
            if (area == null || area.IdArea != id)
            {
                return BadRequest();
            }
            var are = contexto.Area.FirstOrDefault(x => x.IdArea == id);
            if (are == null)
                return NotFound();

            are.IdArea = area.IdArea;
            are.NomeArea = area.NomeArea;

            contexto.Area.Update(are);
            int rs = contexto.SaveChanges();

            if (rs > 0)
                return Ok();
            else
                return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var arere = contexto.Area.Where(x => x.IdArea == id).FirstOrDefault();
            if (arere == null)
            {
                return NotFound();
            }
            contexto.Area.Remove(area);
            int rs = contexto.SaveChanges();
            if (rs > 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}