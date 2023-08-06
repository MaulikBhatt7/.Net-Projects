using System.ComponentModel.DataAnnotations;

namespace Data_Annotation.Models
{
    public class CityModel
    {
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }


        public string? CityCode { get; set; }
        
    }
}
