﻿using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleContatos.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options)
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public object Usuario { get; internal set; }
    }
}
