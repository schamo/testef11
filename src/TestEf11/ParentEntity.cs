using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestEf11
{
    public class ParentEntity
    {
        [Key]
        public int Key { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ChildEntity> Children { get; set; }
    }
}
