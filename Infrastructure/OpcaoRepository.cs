using Poll.Api.Domain;
using Poll.Api.Infrastructure.Context;

namespace Poll.Api.Infrastructure
{
    public class OpcaoRepository : Repository<Opcao>
    {
        public OpcaoRepository(AppDbContext context) : base(context)
        {
        }

        public override Opcao GetById(int id)
        {
            var query = _context.Set<Opcao>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Opcao> GetAll()
        {
            var query = _context.Set<Opcao>();

            return query.Any() ? query.ToList() : new List<Opcao>();
        }
    
    }
}
