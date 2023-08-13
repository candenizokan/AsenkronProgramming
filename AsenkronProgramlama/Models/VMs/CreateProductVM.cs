using System.ComponentModel.DataAnnotations;

namespace AsenkronProgramlama.Models.VMs
{
    public class CreateProductVM
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(0,30000)]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }
        public string Slug => Name.ToLower().Replace(' ', '-');

        //categori için

        [Required(ErrorMessage = "Lütfen Kategori Seçiniz")]
        public int CategoryID { get; set; }
    }
}
