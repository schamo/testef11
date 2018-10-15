using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEf11
{
    public class ChildEntity
    {
        [Key]
        public int Key { get; set; }

        public bool CanRead { get; set; }

        public int ParentKey { get; set; }

        [ForeignKey("ParentKey")]
        public virtual ParentEntity Parent { get; set; }
    }
}
