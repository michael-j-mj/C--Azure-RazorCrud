using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorCrud.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Dispaly Order")]
        public string Name { get; set; }
        [DefaultValue(0)]
        [Range(0,100,ErrorMessage ="Display order must be between 0 and 100")]
        public int DisplayOrder { get; set; } 
    }
}
