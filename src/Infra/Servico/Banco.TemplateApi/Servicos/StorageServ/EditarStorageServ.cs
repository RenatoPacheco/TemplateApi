﻿using System;
using Dapper;
using TemplateApi.Infra.Adaptadores;
using TemplateApi.Dominio.ObjetosDeValor;

namespace TemplateApi.Infra.Servico.Banco.TemplateApi.Servicos.StorageServ
{
    internal class EditarStorageServ
        : BaseSimplesServico
    {
        public EditarStorageServ(
            Conexao conexao,
            EhUnicoStorageServ persEhUnicoStorage)
            : base(conexao)
        {
            _persEhUnicoStorage = persEhUnicoStorage;
        }

        private readonly EhUnicoStorageServ _persEhUnicoStorage;

        public void Executar(Storage dados)
        {
            Notifications.Clear();
            Mapeamentos.StorageMap map = new Mapeamentos.StorageMap();

            IsValid(dados);

            _persEhUnicoStorage.Executar(dados);
            IsValid(_persEhUnicoStorage);

            if (IsValid())
            {
                dados.AlteradoEm = DateTime.Now;

                string sqlString = @$"
                    UPDATE {map.Tabela} SET
                            {map.Col(x => x.Nome)} = @Nome
                           ,{map.Col(x => x.Diretorio)} = @Diretorio
                           ,{map.Col(x => x.Referencia)} = @Referencia
                           ,{map.Col(x => x.Tipo)} = @Tipo
                           ,{map.Col(x => x.Checksum)} = @Checksum
                           ,{map.Col(x => x.Peso)} = @Peso
                           ,{map.Col(x => x.Extensao)} = @Extensao
                           ,{map.Col(x => x.AlteradoEm)} = @AlteradoEm
                           ,{map.Col(x => x.Status)} = @Status
                    WHERE {map.Col(x => x.Id)} = @Id
                ";

                object sqlObject = new
                {
                    Id = dados.Id,
                    Nome = dados.Nome,
                    Diretorio = dados.Diretorio,
                    Referencia = dados.Referencia,
                    Tipo = dados.Tipo,
                    Checksum = dados.Checksum,
                    Peso = dados.Peso,
                    Extensao = dados.Extensao,
                    Status = StatusAdapt.EnumParaSql(dados.Status),
                    AlteradoEm = dados.AlteradoEm
                };

                Conexao.Sessao.Execute(
                    sqlString, sqlObject, Conexao.Transicao);
            }
        }
    }
}
