using Microsoft.AspNetCore.Mvc;
using ProjetoGamer_MVC.Infra;
using ProjetoGamer_MVC.Models;

namespace ProjetoGamer_MVC.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        //INSTANCIA DO CONTEXTO PARA ACESSAR O BANCO DE DADOS
        Context c = new Context();

        [Route("Listar")] //http://localhost/Jogador/Listar:
        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();
            //retorna a view de Jogador(TELA)
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
           Jogador novoJogador = new Jogador();

            novoJogador.Nome = form["Nome"].ToString();

            novoJogador.Email = form["Email"].ToString();

            novoJogador.Senha = form["Senha"].ToString();

            novoJogador.IdEquipe = int.Parse(form["Equipe"].ToString());

            c.Jogador.Add(novoJogador);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador jogadorBuscado = c.Jogador.First(j => j.IdJogador == id);

            c.Remove(jogadorBuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }


        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            Jogador jogador = c.Jogador.First(x => x.IdJogador == id);

            ViewBag.Jogador = jogador;
            ViewBag.Equipe = c.Equipe.ToList();

            return View("Edit");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador jogador = new Jogador();

            jogador.Nome = form["Nome"].ToString();

            jogador.Email = form["Email"].ToString();

            jogador.Senha = form["Senha"].ToString();

            jogador.IdJogador = int.Parse(form["IdJogador"].ToString());

            jogador.IdEquipe = int.Parse(form["Equipe"].ToString());

            Jogador jogadorBuscado = c.Jogador.First(x => x.IdJogador == jogador.IdJogador);

            jogadorBuscado.Nome = jogador.Nome;

            jogadorBuscado.Email = jogador.Email;

            jogadorBuscado.Senha= jogador.Senha;

            jogadorBuscado.IdJogador = jogador.IdJogador;

            jogadorBuscado.IdEquipe = jogador.IdEquipe;

            c.Jogador.Update(jogadorBuscado);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}