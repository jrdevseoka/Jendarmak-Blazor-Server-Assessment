using System.ComponentModel.DataAnnotations;

namespace Assembly.Site.Data.Models
{
    public class DeviceType
    {
        [Required(ErrorMessage ="Device Type should not be empty")]
        public int Key { get; set; }
        
        public string Name { get; set; }
    }
}