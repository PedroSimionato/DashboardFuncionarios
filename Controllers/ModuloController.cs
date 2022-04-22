using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    public class ModuloController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ModuloController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(ModuloDTO moduloDTO)
        {
            if(ModelState.IsValid)
            {
                var modulo = new Modulo();
                modulo.Id = moduloDTO.Id;
                modulo.Nome = moduloDTO.Nome;
                modulo.Status = true;
                _database.Modulos.Add(modulo);
                _database.SaveChanges();
                return RedirectToAction("Modulos", "Adm");
            }
            else
            return View("../Adm/NovoModulo");
        }

        public IActionResult Atualizar(ModuloDTO moduloDTO)
        {
            var modulo = _database.Modulos.First(mod => mod.Id == moduloDTO.Id);
            modulo.Nome = moduloDTO.Nome;
            _database.Modulos.Update(modulo);
            _database.SaveChanges();
            return RedirectToAction("Modulos", "Adm");
        }

        public IActionResult Deletar(int id)
        {
            var modulo = _database.Modulos.First(mod => mod.Id == id);
            modulo.Status = false;
            _database.Modulos.Update(modulo);
            _database.SaveChanges();
            return RedirectToAction("Modulos", "Adm");
        }
        
    }
}