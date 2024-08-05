using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Dados
{
    public class OfertaViagemDal
    {
        private readonly JornadasMilhasContext _context;

        public OfertaViagemDal(JornadasMilhasContext context)
        {
            this._context = context;
        }

        public void Adicionar(OfertaViagem oferta)
        {
            _context.OfertasViagem.Add(oferta);
            _context.SaveChanges();
        }

        public OfertaViagem? RecuperarPorId(int id)
        {
            return _context.OfertasViagem.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<OfertaViagem>? RecuperarPor(Func<OfertaViagem, bool> predicate) => _context.OfertasViagem.Where(predicate);

        public IEnumerable<OfertaViagem> RecuperarTodas()
        {
            return _context.OfertasViagem;
        }

        public void Atualizar(OfertaViagem oferta)
        {
            _context.OfertasViagem.Update(oferta);
            _context.SaveChanges();
        }

        public void Remover(OfertaViagem oferta)
        {
            _context.OfertasViagem.Remove(oferta);
            _context.SaveChanges();
        }

        public OfertaViagem? RecuperaMaiorDesconto(Func<OfertaViagem, bool> filtro)
        {
            return _context.OfertasViagem
                .Where(filtro)
                .Where(c => c.Ativa)
                .OrderBy(c => c.Preco)
                .FirstOrDefault();
        }
    }
}
