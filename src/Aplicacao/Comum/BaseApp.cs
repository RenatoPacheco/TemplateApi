﻿using System.Reflection;
using BitHelp.Core.Validation;
using TemplateApi.Dominio.Servicos;
using TemplateApi.RecursoResx;

namespace TemplateApi.Aplicacao.Comum
{
    public abstract class BaseApp : ISelfValidation
    {
        public BaseApp(
            AutenticacaoServ servAutenticacao)
        {
            _servAutenticacao = servAutenticacao;
        }

        protected readonly AutenticacaoServ _servAutenticacao;

        public ValidationNotification Notifications { get; protected set; } = new ValidationNotification();

        public bool Validate(ISelfValidation valor)
        {
            bool resultado = valor.IsValid();
            Notifications.Add(valor);
            return resultado;
        }

        public bool IsValid()
        {
            return Notifications.IsValid();
        }

        public bool EhAutorizado(MethodBase metodo)
        {
            Notifications.Clear();
            _servAutenticacao.EstaAutorizado(metodo, ValidationType.Unauthorized);
            return Validate(_servAutenticacao);
        }
    }
}