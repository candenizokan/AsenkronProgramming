using System.ComponentModel.DataAnnotations;

namespace AsenkronProgramlama.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")] // boş bırakılamaz
        [MinLength(3, ErrorMessage = "İsim en az 3 karakter olmalı")] //min karakter sayısı
        public string Name { get; set; }

        public string Slug => Name.ToLower().Replace(' ', '-');
    }
}
