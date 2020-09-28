﻿using GerenciamentoIdentidadeCore2.Models.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoIdentidadeCore2.Repositories.Perfil
{
    public interface IPerfilRepository
    {
        public void InserirPerfil(PerfilVD perfil);

        public List<PerfilVD> CarregarListaPerfis();
    }
}
