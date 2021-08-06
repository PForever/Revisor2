using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revisor2.Model.Data
{
    public class Address
    {
        public int Id { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
    }
}