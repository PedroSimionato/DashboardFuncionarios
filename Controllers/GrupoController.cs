using System.Linq;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers
{
    public class GrupoController : Controller
    {

        private readonly ApplicationDbContext _database;

        public GrupoController(ApplicationDbContext database)
        {
            _database = database;
        }
        
        public IActionResult Salvar(GrupoDTO grupoDTO)
        {
            if(ModelState.IsValid)
            {
                var grupo = new Grupo();
                grupo.Id = grupoDTO.Id;
                grupo.ScrumMaster = _database.Scrums.First(s => s.Id == grupoDTO.ScrumMasterId);
                grupo.Tecnologia = _database.Tecnologias.First(tec => tec.Id == grupoDTO.TecnologiaId);
                grupo.Status = true;
                _database.Grupos.Add(grupo);
                _database.SaveChanges();
                ViewBag.Startes = _database.Starters.Where(st => st.Grupo == null).ToList();
                return RedirectToAction("Grupos", "Adm");
            }
            else
            {
                ViewBag.Scrums = _database.Scrums.ToList();
                ViewBag.Tecnologias = _database.Tecnologias.ToList();
                return View("../Adm/NovoGrupo");
            }
        }

         public IActionResult Atualizar(GrupoDTO grupoDTO)
        {
            var grupo = _database.Grupos.First(g => g.Id == grupoDTO.Id);
            // grupo.ScrumMaster = _database.Scrums.First(sc => sc.Id == grupoDTO.ScrumMasterId);
            grupo.Tecnologia = _database.Tecnologias.First(tec => tec.Id == grupoDTO.TecnologiaId);
            _database.Grupos.Update(grupo);
            _database.SaveChanges();
            return RedirectToAction("Grupos", "Adm");
        }

            public IActionResult Deletar(int id)
        {
            var grupo = _database.Grupos.First(g => g.Id == id);
            grupo.Status = false;
            _database.Grupos.Update(grupo);
            _database.SaveChanges();
            return RedirectToAction("Grupos", "Adm");
        }

        public IActionResult Gerenciar(int id)
        {
            var grupos = _database.Grupos.First(gr => gr.Id == id);
            ViewBag.Scrums = _database.Scrums.ToList();
            ViewBag.Tecnologias = _database.Tecnologias.ToList();
            ViewBag.Starters = _database.Starters.Where(st => st.Grupo.Id == id).ToList();
            ViewBag.Modulos = _database.Modulos.Include(mod => mod.ModuloGrupos).ThenInclude(mod => mod.Modulo )
            .ToList();
            return View(grupos);
        }

        public IActionResult AdicionarParticipante(int id)
        {
            // var grupo = _database.Grupos.Include(gr => gr.ScrumMaster).Include(grupo=>grupo.Tecnologia).First(gr => gr.Id == id);
            var grupoStarterDTO = new GrupoStarterDTO();
            // grupoStarterDTO.Id = grupo.Id;
            // grupoStarterDTO.ScrumMasterId = grupo.ScrumMaster.Id;
            // grupoStarterDTO.TecnologiaId = grupo.Tecnologia.Id;
            ViewBag.Starters = _database.Starters.Where(st => st.Tecnologia.Id == grupoStarterDTO.TecnologiaId
            && st.Grupo == null).ToList();
            return View(grupoStarterDTO);
        }

        public IActionResult SalvarParticipante(GrupoStarterDTO grupostarterDTO)
        {
            var starter = _database.Starters.Include(st => st.Tecnologia).Include(st => st.Programa).
            First(st => st.Id == grupostarterDTO.StartersId);
            // var grupo = _database.Grupos.Include(gr => gr.ScrumMaster).Include(gr => gr.Tecnologia)
            // .First(gr => gr.Id == grupostarterDTO.Id);
            // starter.Grupo = grupo;
            // starter.Grupo.Id = grupo.Id;
            _database.Starters.Update(starter);
            _database.SaveChanges();     
            return RedirectToAction("Gerenciar", "Grupo");
        }

        public IActionResult AdicionarModulo(int id)
        {
            var grupoModulo = new GrupoModuloDTO();
            grupoModulo.GrupoId = id;
            ViewBag.Modulos = _database.Modulos.ToList();
            return View(grupoModulo);
        }

        public IActionResult SalvarModulo(GrupoModuloDTO grupoModuloDTO)
        {
            var moduloGrupo = new ModuloGrupo();
            moduloGrupo.GrupoId = grupoModuloDTO.Id;
            moduloGrupo.GrupoId = grupoModuloDTO.GrupoId;
            moduloGrupo.ModuloId = grupoModuloDTO.ModuloId;
            _database.ModuloGrupos.Add(moduloGrupo);
            _database.SaveChanges();
            return RedirectToAction("Gerenciar", "Grupo");
        }       
    }
}