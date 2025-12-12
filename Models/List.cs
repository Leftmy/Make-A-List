using MakeAList.Models;
using System.ComponentModel.DataAnnotations;

public class List
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = "";

    public ListType Type { get; set; }

    public string UserId { get; set; } = "";
    public ApplicationUser? User { get; set; }

    public ICollection<ListItem> Items { get; set; } = new List<ListItem>();
}
