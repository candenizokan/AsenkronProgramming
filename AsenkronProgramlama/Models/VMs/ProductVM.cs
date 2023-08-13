using AsenkronProgramlama.Models.Enums;

namespace AsenkronProgramlama.Models.VMs
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public Statu Statu { get; set; }
        public int Stock { get; set; }
        //categori için
        public string CategoryName { get; set; }
    }
}
