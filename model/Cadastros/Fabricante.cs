﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Modelo.Tabelas;

namespace Modelo.Cadastros;
{
    public class Fabricante
    {
        public long FabricanteId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}