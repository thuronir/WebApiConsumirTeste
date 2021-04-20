using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppWaConsuming.Models
{
    public class PedidosModel
    {
        public int CodigoPedido { get; set; }
        public string DataCriacao { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public string DataEntrega { get; set; }
        public string Equipe { get; set; }
        public string Endereco { get; set; }
    }
}