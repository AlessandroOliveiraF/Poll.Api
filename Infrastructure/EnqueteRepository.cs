using Poll.Api.Domain;
using Poll.Api.Infrastructure.Context;

namespace Poll.Api.Infrastructure
{
    public class EnqueteRepository : Repository<Enquete>
    {
        public EnqueteRepository(AppDbContext context) : base(context)
        {
        }

        public override Enquete GetById(int id)
        {
            var query = _context.Set<Enquete>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Enquete> GetAll()
        {
            var query = _context.Set<Enquete>();

            return query.Any() ? query.ToList() : new List<Enquete>();
        }
    }
}
