using System.ComponentModel.DataAnnotations;

namespace TestCoreApp.Models
{
    public class Item
    {
        private const string msg = "قيمة الحقل يجب أن تكون بين " +
                    "(100)" +
                    "و" +
                    "1000";

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="حقل الإسم مطلوب")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "من فضـلك أكتب سعر")]
        [Range(100,1000,
            ErrorMessage = msg)]
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
