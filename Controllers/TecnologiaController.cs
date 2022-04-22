using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    public class TecnologiaController : Controller
    {
        private readonly ApplicationDbContext _database;

        public TecnologiaController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(TecnologiaDTO tecnologiaDTO)
        {
            if(ModelState.IsValid)
            {
                var tecnologia = new Tecnologia();
                tecnologia.Id = tecnologiaDTO.Id;
                tecnologia.Tipo = tecnologiaDTO.Tipo;
                tecnologia.Descricao = tecnologiaDTO.Descricao;
                _database.Tecnologias.Add(tecnologia);
                _database.SaveChanges();
                return RedirectToAction("Index", "Adm");
            }
            else
            return View("../Adm/NovaTecnologia");
        }
        
    }
}