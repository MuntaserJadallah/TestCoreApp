using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestCoreApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("فئة الصنف")]
        [Required(ErrorMessage ="يجب كتابة إسم الفئة")]
        public required string Cat_Name { get; set; }
        public DateTime CreatedDate { get;set; } = DateTime.Now;
    }
}
