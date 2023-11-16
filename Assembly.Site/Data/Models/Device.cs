using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assembly.Site.Data.Models
{
    [Table("DEVICES")]
    [Index(nameof(Name), IsUnique = true)]
    public class Device
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }

        
        [Column("NAME")]
        [Required(ErrorMessage ="Device name should not be empty")]
        public string Name { get; set; }

        [Column("TYPE")]
        [Required(ErrorMessage ="Device type should not be empty")]
        public EDeviceType DeviceType { get; set; }
    }
}
