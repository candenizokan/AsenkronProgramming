using AsenkronProgramlama.Models.Entities.Abstract;
using System.Collections.Generic;
using System.IO;

namespace AsenkronProgramlama.Models.Entities.Concrete
{
    public class Category : BaseEntity
    {

        public string Name { get; set; }
        public string Slug { get; set; }

        //Navigation Prop

        //bir ürünün bir kategorisi  kategorinin çokça ürünü
        public List<Product> Products { get; set; }

    }
}
