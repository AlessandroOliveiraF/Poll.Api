using Poll.Api.Domain;
using Poll.Api.Infrastructure.Interface;

namespace Poll.Api.Services
{
    public class EnqueteService
    {
        private readonly IRepository<Enquete> _enqueteRepository;
        private readonly IRepository<Opcao> _opcaoRepository;

        public EnqueteService(IRepository<Enquete> enqueteRepository, IRepository<Opcao> opcaoRepository)
        {
            _enqueteRepository = enqueteRepository;
            _opcaoRepository = opcaoRepository;
        }

        public IEnumerable<Enquete> ListarEnquetes()
        {
            return _enqueteRepository.GetAll();
        }

        public Enquete BuscarEnquete(int id)
        {
            return _enqueteRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            var enquete = _enqueteRepository.GetById(id);

            if (enquete != null)
            {
                if(enquete.Opcoes.Count > 0)
                { 
                    foreach (var opcao in enquete.Opcoes)
                    {
                        _opcaoRepository.Delete(opcao);
                    }
                }

                _enqueteRepository.Delete(enquete);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add(Enquete enquete)
        {
            if (enquete != null)
            {
                _enqueteRepository.Insert(enquete);
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool Update(int id, Enquete enquete)
        {
            var enqueteAntiga = _enqueteRepository.GetById(id);

            if (enquete != null)
            {
                if (enqueteAntiga.Opcoes.Count > 0)
                {
                    foreach (var opcaoAntiga in enqueteAntiga.Opcoes)
                    {
                        _opcaoRepository.Delete(opcaoAntiga);
                    }                    

                    foreach (var opcao in enquete.Opcoes)
                    {
                        _opcaoRepository.Insert(opcao);
                    }
                }

                _enqueteRepository.Update(enquete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
