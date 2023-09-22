using Fiap.Web.Aula02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Aula02.Controllers
{
    public class MotoristaController : Controller
    {

        private static IList<Motorista> _motoristaList = new List<Motorista>();
        private static int _id = 0;

        public IActionResult Index()
        {
            return View(_motoristaList);
        }

        [HttpGet]
        public IActionResult CadastrarMotorista()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarMotorista(Motorista motorista)
        {
            motorista.Id = ++_id;
            _motoristaList.Add(motorista);

            TempData["mostrarMensagem"] = true;
            TempData["mensagem"] = "Motorista cadastrado com SUCESSO!";

            return RedirectToAction("CadastrarMotorista");
        }

        [HttpGet]
        public IActionResult AtualizarMotorista(int id)
        {
            var motorista = _motoristaList.First(m => m.Id == id);
            return View(motorista);
        }

        [HttpPost]
        public IActionResult AtualizarMotorista(Motorista motorista)
        {
            var index = _motoristaList.ToList().FindIndex(m => m.Id == motorista.Id);
            _motoristaList[index] = motorista;

            TempData["mostrarMensagem"] = true;
            TempData["mensagem"] = "Veiculo atualizado com SUCESSO!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletarMotorista(int id)
        {
            _motoristaList.Remove(_motoristaList.First(m => m.Id == id));
            TempData["mostrarMensagem"] = true;
            TempData["mensagem"] = "Motorista Removido";
            return RedirectToAction("Index");
        }
            
    }
}
