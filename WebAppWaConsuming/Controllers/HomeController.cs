using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppWaConsuming.Models;

namespace WebAppWaConsuming.Controllers
{
    public class HomeController : Controller
    {
        string BaseUrl = "https://localhost:44336/api/ProdutoPedidos/";
        string Token = "6(qk~Tvapyof}y)M0%HXeoGSkx%v@F=g&en6<|We0jB2X.3@=avKUEW;*qIX*;1DB673CAFF6C3B635A14ADF98439E";

        public async Task<ActionResult> Index()
        {
            try
            {
                List<PedidosModel> oPedidosModel = new List<PedidosModel>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
                    HttpResponseMessage httpResponse = await client.GetAsync(Token);
                    if (httpResponse.IsSuccessStatusCode)
                    { 
                        var Data = httpResponse.Content.ReadAsStringAsync().Result;
                        List<ProdutoPedido> oProdutoPedido = JsonConvert.DeserializeObject<List<ProdutoPedido>>(Data);
                        oPedidosModel = (from ProdutoPedido Pd in oProdutoPedido
                                   select new PedidosModel()
                                   {
                                       CodigoPedido = Pd.PedidoId,
                                       DataCriacao = Pd.Pedido.DataCriacao.ToString("dd/MM/yyyy"),
                                       Produto = Pd.Produto.Nome,
                                       Quantidade = Pd.Quantidade,
                                       DataEntrega = Pd.Pedido.DataEntrega.ToString("dd/MM/yyyy"),
                                       Equipe = Pd.Pedido.Equipe.Nome,
                                       Endereco = Pd.Pedido.Endereco
                                   }).ToList();
                    }
                    return View(oPedidosModel);
                }
            }
            catch
            {
                return View("Error");
            }
        }

    }
}