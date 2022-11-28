using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IConfiguration _configuration;
        public AlunosController(IAlunoRepositorio alunoRepositorio, IConfiguration configuration)
        {
            _alunoRepositorio = alunoRepositorio;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            try
            {
                var alunos = _alunoRepositorio.BuscarAlunos();
                return View(alunos);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ocorreu um erro de conexão com o Banco de Dados, tente novamente mais tarde.";
                return View("index");
            }

        }
        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult InserirAluno(AlunoModel aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);

                TempData["MensagemSucesso"] = "Aluno adicionado com sucesso!";
                return RedirectToAction("Index");

            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao adicionar o aluno, tente novamente mais tarde.";
                return RedirectToAction("Index");
            }

            // Poderia ser return RedirectToAction("Index"); -> Pois redireciona para a tela na View aluno Index que é a principal
        }

        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            return View(aluno);

        }

        public IActionResult Atualizar(AlunoModel aluno)
        {
            try
            {
                _alunoRepositorio.Atualizar(aluno);
                TempData["EditarSucesso"] = $"Dados do aluno {aluno.nome} editado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["EditarErro"] = $"Dados do aluno {aluno.nome} editado com sucesso!";
                return RedirectToAction("Index");
            }

        }

        public IActionResult RemoverAluno(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            _alunoRepositorio.ExcluirAluno(aluno);
            return RedirectToAction("Index");
        }

        public IActionResult ExcluirAluno(AlunoModel aluno)
        {
            _alunoRepositorio.ExcluirAluno(aluno);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");

                EnderecoModel enderecoModel = new();

                using var cliente = new HttpClient();

                var result = await cliente.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                }

                return View("Endereco", enderecoModel);
            }
            catch (System.Exception)
            {

                throw;
            }

        }


    }
}
