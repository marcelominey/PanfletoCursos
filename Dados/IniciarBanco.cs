using System.Linq;
using PanfletoCursos.Models;

namespace PanfletoCursos.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(PanfletoContexto contexto)
        {
            contexto.Database.EnsureCreated();
            //Aqui já cria o BD com as tabelas.
            //serve para verificar se o BD foi criado

            //agora vou colocar um dado lá dentro, só para testar. Se não tem, ele cria uma linha lá dentro (era algo assim?)
            if (contexto.Area.Any())
            {
                //Any é um comando do LINQ
                return;
            }
            var area = new Area() { NomeArea = "Trabalhos Manuais"};
            contexto.Area.Add(area);
            
            contexto.SaveChanges();
        }
    }
}