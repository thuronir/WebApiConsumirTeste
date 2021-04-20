﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppWaConsuming.Models
{
    public class ProdutoPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}