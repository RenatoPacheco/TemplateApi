﻿using Xunit;
using TemplateApi.Compartilhado.ObjetosDeValor;

namespace TemplateApi.Teste.Compartilhado.ObjetosDeValor
{
    public class BoolInputTeste
    {
        [Theory]
        [InlineData("true", true)]
        [InlineData("TRUE", true)]
        [InlineData("false", true)]
        [InlineData("FALSE", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("0", false)]
        [InlineData("1", false)]
        [InlineData("texto", false)]
        public void Receber_string(string entrada, bool ehValido)
        {
            BoolInput valor = new(entrada);

            Assert.Equal(ehValido, valor.IsValid());

            valor = (BoolInput)entrada;

            Assert.Equal(ehValido, valor.IsValid());
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, true)]
        [InlineData(null, false)]
        public void Receber_boolean_que_pode_ser_nulo(bool? entrada, bool ehValido)
        {
            BoolInput valor = new(entrada);

            Assert.Equal(ehValido, valor.IsValid());

            valor = (BoolInput)entrada;

            Assert.Equal(ehValido, valor.IsValid());
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, true)]
        public void Receber_boolean(bool entrada, bool ehValido)
        {
            BoolInput valor = new(entrada);

            Assert.Equal(ehValido, valor.IsValid());

            valor = (BoolInput)entrada;

            Assert.Equal(ehValido, valor.IsValid());
        }
    }
}
