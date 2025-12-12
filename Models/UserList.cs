using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MakeAList.Models
{
    public class UserList
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public ListType Type { get; set; }

        public string UserId { get; set; } = "";
        public IdentityUser? User { get; set; }

        public List<ListItem> Items { get; set; } = new();
    }
}
