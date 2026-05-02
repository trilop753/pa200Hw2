using System.ComponentModel.DataAnnotations;

namespace CloudComputingHomeworkApp.Models;

public class Person
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Favourite Number")]
    public int FavouriteNumber { get; set; }
}
