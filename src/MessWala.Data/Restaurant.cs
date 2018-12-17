using System.ComponentModel.DataAnnotations;

namespace MessWala.Data
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId {get;set;}
        public string Name { get; set; }
    }
}