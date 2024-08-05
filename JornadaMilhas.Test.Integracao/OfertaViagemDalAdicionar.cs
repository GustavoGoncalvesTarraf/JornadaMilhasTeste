using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao
{
    [Collection(nameof(ContextoCollection))]
    public class OfertaViagemDalAdicionar
    {
        private readonly JornadasMilhasContext context;

        public OfertaViagemDalAdicionar(ITestOutputHelper output, ContextoFixture fixture)
        {
            context = fixture.Context;
            output.WriteLine(context.GetHashCode().ToString());
        }

        [Fact]
        public void RegistraOfertaNoBanco()
        {

            //Arrange 
            Rota rota = new Rota("São Paulo", "Fortaleza");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = 350;

            var oferta = new OfertaViagem(rota, periodo, preco);
            var dal = new OfertaViagemDal(context);
            //Act 
            dal.Adicionar(oferta);

            //Assert
            var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
            Assert.NotNull(ofertaIncluida);
            Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.0001);

        }

        [Fact]
        public void RegistraOfertaNoBancoComInformacoesCorretas()
        {

            //Arrange 
            Rota rota = new Rota("São Paulo", "Fortaleza");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = 350;

            var oferta = new OfertaViagem(rota, periodo, preco);
            var dal = new OfertaViagemDal(context);
            //Act 
            dal.Adicionar(oferta);

            //Assert
            var ofertaIncluida = dal.RecuperarPorId(oferta.Id);
            Assert.Equal(ofertaIncluida.Rota.Origem, oferta.Rota.Origem);
            Assert.Equal(ofertaIncluida.Rota.Destino, oferta.Rota.Destino);
            Assert.Equal(ofertaIncluida.Periodo.DataInicial, oferta.Periodo.DataInicial);
            Assert.Equal(ofertaIncluida.Periodo.DataFinal, oferta.Periodo.DataFinal);
            Assert.Equal(ofertaIncluida.Preco, oferta.Preco, 0.0001);
        }
    }
}