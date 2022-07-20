﻿using BitHelp.Core.Validation.Extends;
using TemplateApi.Dominio.Servicos;
using TemplateApi.Dominio.Comandos.StorageCmds;
using TemplateApi.Dominio.ObjetosDeValor;
using System.Collections.Generic;
using TemplateApi.Compartilhado.ObjetosDeValor;
using System;

namespace TemplateApi.Aplicacao.Intreceptadores
{
    public class StorageInter : Comum.BaseInter
    {
        public StorageInter(
            AutenticacaoServ servAutenticacao)
            : base(servAutenticacao) { }

        internal void Obter(ObterStorageCmd comando)
        {
            if (!_servAutenticacao.EstaAutenticado())
            {
                if (!comando.HasNotification(x => x.Status))
                {
                    comando.Status = new List<Status>() { Status.Ativo };
                }
            }
        }

        internal void Filtrar(FiltrarStorageCmd comando)
        {
            if (!_servAutenticacao.EstaAutenticado())
            {
                if (!comando.HasNotification(x => x.Status))
                {
                    comando.Status = new List<Status>() { Status.Ativo };
                }
            }
        }

        internal void Excluir(ExcluirStorageCmd comando)
        {

        }

        internal void Editar(EditarStorageCmd comando)
        {

        }

        internal void Inserir(InserirStorageCmd comando)
        {

        }
    }
}
