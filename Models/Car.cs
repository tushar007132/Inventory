using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool New { get; set; }
    }
}
