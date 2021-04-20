using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppWaConsuming.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Endereco { get; set; }
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }
    }
}