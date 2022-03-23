using Poll.Api.Domain;
using Poll.Api.Infrastructure.Interface;

namespace Poll.Api.Services
{
    public class OpcaoService
    {
        private readonly IRepository<Opcao> _opcaoRepository;
        private readonly IRepository<Enquete> _enqueteRepository;

        public OpcaoService(IRepository<Opcao> opcaoRepository, IRepository<Enquete> enqueteRepository)
        {
            _opcaoRepository = opcaoRepository;
            _enqueteRepository = enqueteRepository;
        }

        public IEnumerable<Opcao> ListarOpcoes()
        {
            return _opcaoRepository.GetAll();
        }

        public Opcao BuscarOpcao(int id)
        {
            return _opcaoRepository.GetById(id);
        }

        public void Save(int id, string opcaoDescricao)
        {
            var enquete = _enqueteRepository.GetById(id);

            if(enquete != null)
            { 
                if (opcaoDescricao != null)
                {
                    var opcao = new Opcao(opcaoDescricao, enquete.Id);
                    _opcaoRepository.Insert(opcao);
                }
            }
        }

        public void Delete(int id)
        {
            var opcao = _opcaoRepository.GetById(id);

            if (opcao != null)
            {
                _opcaoRepository.Delete(opcao);
            }
        }

        public void Insert(Opcao opcao)
        {
            if (opcao != null)
            {
                _opcaoRepository.Insert(opcao);
            }
        }
    }
}
