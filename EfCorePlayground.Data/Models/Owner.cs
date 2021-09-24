using System.Collections.Generic;

namespace EfCorePlayground.Data.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
