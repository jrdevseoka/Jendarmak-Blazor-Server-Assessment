using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assembly.Site.Data.Models
{
    [Table("OPERATIONS")]
    [Index(nameof(Name), IsUnique = true)]
    public class Operation
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperationID { get; set; }

        [Column("NAME")]
        [Required(ErrorMessage = "Operation name cannot be empty.")]
        public string Name { get; set; }

        [Required]
        [Column("PIORITY")]
        public int OrderInWhichToPerform { get; set; }


        [Column("IMAGE")]
        [Required(ErrorMessage = "Operation image cannot be empty.")]
        public byte[] ImageData { get; set; }
        [Required(ErrorMessage ="Device cannot be empty")]
        [ForeignKey("DEVICEID")]
        public  Device Device { get; set; }
    }
}
