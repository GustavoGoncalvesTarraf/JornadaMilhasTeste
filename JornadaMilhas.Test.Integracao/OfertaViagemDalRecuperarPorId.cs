using JornadaMilhas.Dados;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao
{
    [Collection(nameof(ContextoCollection))]
    public class OfertaViagemDalRecuperarPorId
    {
        private readonly JornadasMilhasContext context;
        public OfertaViagemDalRecuperarPorId(ITestOutputHelper output, ContextoFixture fixture)
        {
            context = fixture.Context;
            output.WriteLine(context.GetHashCode().ToString());
        }

        [Fact]
        public void RetornaNuloQuandoIdInexistente()
        {
            //Arrange
            var dal = new OfertaViagemDal(context);

            //Act
            var ofertaRecuperada = dal.RecuperarPorId(-2);

            //Assert
            Assert.Null(ofertaRecuperada);
        } 
    }
}
