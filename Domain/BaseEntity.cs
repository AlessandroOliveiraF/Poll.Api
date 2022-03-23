using System.ComponentModel.DataAnnotations;

namespace Poll.Api.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; private set; }
    }
}
