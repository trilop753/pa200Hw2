using System.ComponentModel.DataAnnotations;

namespace CloudComputingHomeworkApp.Models;

public class HomeIndexViewModel
{
    public List<Person> Persons { get; set; } = [];

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Favourite Number")]
    public int? FavouriteNumber { get; set; }
}
