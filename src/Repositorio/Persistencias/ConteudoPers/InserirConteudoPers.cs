﻿using System;
using Dapper;
using DotNetCore.API.Template.Dominio.Entidades;
using DotNetCore.API.Template.Dominio.Interfaces;
using DotNetCore.API.Template.Repositorio.Contexto;
using DotNetCore.API.Template.Repositorio.Adaptadores;
using DotNetCore.API.Template.Repositorio.MapeamentoSql;

namespace DotNetCore.API.Template.Repositorio.Persistencias.ConteudoPers
{
    internal class InserirConteudoPers : Comum.SimplesRep
    {
        public InserirConteudoPers(
            Conexao conexao,
            IUnidadeTrabalho udt,
            EhUnicoConteudoPers persEhUnicoConteudo)
            : base(conexao, udt)
        {
            _persEhUnicoConteudo = persEhUnicoConteudo;
        }

        private readonly EhUnicoConteudoPers _persEhUnicoConteudo;

        public void Inserir(Conteudo dados)
        {
            Notifications.Clear();
            ConteudoMapSql json = new ConteudoMapSql();

            Validate(dados);

            _persEhUnicoConteudo.EhUnico(dados);
            Validate(_persEhUnicoConteudo);

            if (IsValid())
            {
                dados.CriadoEm = DateTime.Now;
                dados.AlteradoEm = DateTime.Now;

                string sqlString = @$"
                    INSERT INTO [dbo].[{json.Tabela}]
                           ([{json.Coluna(x => x.Titulo)}]
                           ,[{json.Coluna(x => x.Alias)}]
                           ,[{json.Coluna(x => x.Texto)}]
                           ,[{json.Coluna(x => x.CriadoEm)}]
                           ,[{json.Coluna(x => x.AlteradoEm)}]
                           ,[{json.Coluna(x => x.Status)}])
                    VALUES
                           (@Titulo
                           ,@Alias
                           ,@Texto
                           ,@CriadoEm
                           ,@AlteradoEm
                           ,@Status); 
                    SELECT CAST(SCOPE_IDENTITY() as int);
                ";

                object sqlObject = new
                {
                    Titulo = new DbString { Value = dados.Titulo, IsAnsi = true },
                    Alias = new DbString { Value = dados.Alias, IsAnsi = true },
                    Texto = new DbString { Value = dados.Texto, IsAnsi = true },
                    Status = new DbString { Value = StatusAdapt.EnumParaSql(dados.Status), IsAnsi = true },
                    CriadoEm = dados.CriadoEm,
                    AlteradoEm = dados.AlteradoEm
                };

                dados.Id = Conexao.Sessao.QuerySingle<int>(
                    sqlString, sqlObject, Conexao.Transicao);
            }
        }
    }
}
