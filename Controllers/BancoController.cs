using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    public class BancoController : Controller
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<IdentityUser> _userManager;

        public BancoController(ApplicationDbContext database, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _database = database;
        }

        public async Task<IActionResult> Popular()
        {
            if (_database.Tecnologias.ToList().Count == 0)
            {
                var tec1 = new Tecnologia();
                tec1.Id = 1;
                tec1.Tipo = ".NET";
                tec1.Descricao = "C#, EF Core, Identity, Razor";
                var tec2 = new Tecnologia();
                tec2.Id = 2;
                tec2.Tipo = "Java";
                tec2.Descricao = "Java, MySQL, Intelij";
        
                var turma1 = new ProgramaStarter();
                turma1.Id = 1;
                turma1.Turma = 1;
                turma1.Inicio = new DateTime(2021, 11, 03);
                turma1.Fim = new DateTime(2022, 01, 28);
                turma1.Status = true;

                var mod1 = new Modulo();
                mod1.Id = 1;
                mod1.Nome = "MVC";
                mod1.Status = true;
                var mod2 = new Modulo();
                mod2.Id = 2;
                mod2.Nome = "API";
                mod2.Status = true;
                var mod3 = new Modulo();
                mod3.Id = 3;
                mod3.Nome = "TDD";
                mod3.Status = true;

                var adm = new IdentityUser{
                    UserName = "clecio.silva@gft.com",
                    Email = "clecio.silva@gft.com"
                };
                var result = await _userManager.CreateAsync(adm, "Gft2021");
                if(result.Succeeded)
                {
                    await _userManager.AddClaimAsync(adm, new Claim("Email", "clecio.silva@gft.com"));
                }

                var scrum = new IdentityUser{
                    UserName = "scrum.master@gft.com",
                    Email = "scrum.master@gft.com"
                };
                var resultScrum = await _userManager.CreateAsync(scrum, "Scrum2021");
                if(resultScrum.Succeeded)
                {
                    await _userManager.AddClaimAsync(scrum, new Claim("Nome", "Scrum"));
                    await _userManager.AddClaimAsync(scrum, new Claim("4Letras", "SCRU"));
                    await _userManager.AddClaimAsync(scrum, new Claim("Email", "scrum.master@gft.com"));
                }
                
                var sm = new ScrumMaster();
                sm.Id = 1;
                sm.Nome = "Scrum";
                sm.Email = "scrum.master@gft.com";
                sm.Letras = "SCRU";
                

                var grupo1 = new Grupo();
                grupo1.Id = 1;
                grupo1.Tecnologia = tec1;
                grupo1.ScrumMaster = sm;
                grupo1.Status = true;

                var grupo2 = new Grupo();
                grupo2.Id = 2;
                grupo2.Tecnologia = tec2;
                grupo2.ScrumMaster = sm;
                grupo2.Status = true;

                var starter = new Starter();
                starter.Id = 1;
                starter.Nome = "Pedro";
                starter.Letras = "POSM";
                starter.Tecnologia = tec1;
                starter.Programa = turma1;
                starter.Grupo = grupo1;
                starter.Status = true;

                var starter2 = new Starter();
                starter2.Id = 2;
                starter2.Nome = "Joao";
                starter2.Letras = "JOAO";
                starter2.Tecnologia = tec2;
                starter2.Programa = turma1;
                starter2.Grupo = grupo2;
                starter2.Status = true;

                var starter3 = new Starter();
                starter3.Id = 3;
                starter3.Nome = "Lucas";
                starter3.Letras = "LUCA";
                starter3.Tecnologia = tec1;
                starter3.Programa = turma1;
                starter3.Grupo = grupo1;
                starter3.Status = true;

                var starter4 = new Starter();
                starter4.Id = 4;
                starter4.Nome = "Maria";
                starter4.Letras = "MARI";
                starter4.Tecnologia = tec2;
                starter4.Programa = turma1;
                starter4.Grupo = grupo2;
                starter4.Status = true;

                var proj1 = new Projeto();
                proj1.Id = 1;
                proj1.Avaliacao = 10;
                proj1.Comentario = "Projeto entregue, com todos os requisitos e exceeds";
                proj1.Modulo = mod1;
                proj1.Starter = starter;
                proj1.Status = true;

                var proj2 = new Projeto();
                proj1.Id = 2;
                proj1.Avaliacao = 8;
                proj1.Comentario = "Projeto entregue, com todos os requisitos mas sem exceeds";
                proj1.Modulo = mod1;
                proj1.Starter = starter2;
                proj1.Status = true;

                var proj3 = new Projeto();
                proj1.Id = 3;
                proj1.Avaliacao = 8;
                proj1.Comentario = "Projeto entregue, com todos os requisitos mas sem exceeds";
                proj1.Modulo = mod1;
                proj1.Starter = starter3;
                proj1.Status = true;

                var proj4 = new Projeto();
                proj1.Id = 4;
                proj1.Avaliacao = 10;
                proj1.Comentario = "Projeto entregue, com todos os requisitos e exceeds";
                proj1.Modulo = mod1;
                proj1.Starter = starter4;
                proj1.Status = true;

                var daily1 = new Daily();
                daily1.Id = 1;
                daily1.Data = new DateTime(2021, 12, 02);
                daily1.Feito = "Corrigido bug do banco de dados";
                daily1.Fazendo = "Implementando migrations no projeto";
                daily1.Impedimento = "Sem impedimentos";
                daily1.Presenca = true;
                daily1.Modulo = mod1;
                daily1.Starter = starter;
                daily1.Status = true;

                var daily2 = new Daily();
                daily2.Id = 2;
                daily2.Data = new DateTime(2021, 12, 02);
                daily2.Feito = "UML do projeto";
                daily2.Fazendo = "Criando o identity";
                daily2.Impedimento = "Dificuldade em relacionar as entidades";
                daily2.Presenca = true;
                daily2.Modulo = mod1;
                daily2.Starter = starter2;
                daily2.Status = true;

                var daily3 = new Daily();
                daily3.Id = 3;
                daily3.Data = new DateTime(2021, 12, 02);
                daily3.Feito = "Realizou as migrations";
                daily3.Fazendo = "Classes DTO do projeto";
                daily3.Impedimento = "Sem impedimentos";
                daily3.Presenca = true;
                daily3.Modulo = mod1;
                daily3.Starter = starter3;
                daily3.Status = true;

                var daily4 = new Daily();
                daily4.Id = 4;
                daily4.Data = new DateTime(2021, 12, 02);
                daily4.Feito = "Implementou o Identity";
                daily4.Fazendo = "Corrigindo o bud do banco de dados";
                daily4.Impedimento = "Sem impedimentos";
                daily4.Presenca = false;
                daily4.Modulo = mod1;
                daily4.Starter = starter4;
                daily4.Status = true;

                var grupoModulo = new ModuloGrupo();
                grupoModulo.Id = 1;
                grupoModulo.ModuloId = 1;
                grupoModulo.GrupoId = 1;

                var grupoModulo1 = new ModuloGrupo();
                grupoModulo1.Id = 2;
                grupoModulo1.ModuloId = 1;
                grupoModulo1.GrupoId = 2;

                _database.Tecnologias.Add(tec1);
                _database.Tecnologias.Add(tec2);
                _database.Programas.Add(turma1);
                _database.Modulos.Add(mod1);
                _database.Modulos.Add(mod2);
                _database.Modulos.Add(mod3);
                _database.Scrums.Add(sm);
                _database.Grupos.Add(grupo1);
                _database.Grupos.Add(grupo2);
                _database.Starters.Add(starter);
                _database.Starters.Add(starter2);
                _database.Starters.Add(starter3);
                _database.Starters.Add(starter4);
                _database.Projetos.Add(proj1);
                _database.Projetos.Add(proj2);
                _database.Projetos.Add(proj3);
                _database.Projetos.Add(proj4);
                _database.Dailys.Add(daily1);
                _database.Dailys.Add(daily2);
                _database.Dailys.Add(daily3);
                _database.Dailys.Add(daily4);
                _database.SaveChanges();
            }         
                        
            return RedirectToAction("Index", "Home");
        }
        
    }
}