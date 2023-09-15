using Fiap.Web.Aula02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Aula02.Controllers
{
    public class VeiculoController : Controller
    {
        //Lista para gravar os veiculos
        private static IList<Veiculo> _lista = new List<Veiculo>();
        private static int _id = 0;

        public IActionResult Index()
        {
            return View(_lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            veiculo.Id = ++_id;
            //Cadastrar na lista
            _lista.Add(veiculo);

            //Mostrar mensagem de sucesso
            // Após cadastrar o veículo com sucesso
            TempData["mostrarMensagem"] = true;
            TempData["mensagem"] = "Veiculo cadastrado com SUCESSO!";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var veiculo = _lista.First(v => v.Id == id);
            return View(veiculo);
        }

        [HttpPost]
        public IActionResult Atualizar(Veiculo veiculo)
        {
            var index = _lista.ToList().FindIndex(v => v.Id == veiculo.Id);
            _lista[index] = veiculo;

            TempData["mostrarMensagem"] = true;
            TempData["mensagem"] = "Veiculo atualizado com SUCESSO!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            var veiculo = _lista.First(v => v.Id == id);
            //_lista.Remove(veiculo);
            return View(veiculo);
            //return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult Deletar(Veiculo veiculo, int id)
        {
            veiculo = _lista.First(v => v.Id == id);
            _lista.Remove(veiculo);
            //return View(veiculo);
            return RedirectToAction("Index");
        }
    }
}
