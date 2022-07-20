﻿using System;
using BitHelp.Core.Type.pt_BR;
using BitHelp.Core.Validation.Notations;
using BitHelp.Core.Validation.Resources;

namespace TemplateApi.Compartilhado.Validacoes.Notacoes
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class PhoneTypeIsValidAttribute : ListIsValidAttribute
    {
        public PhoneTypeIsValidAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Resource.XNotValid);
        }

        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);
            return PhoneType.TryParse(input, out _);
        }
    }
}
