using System.ComponentModel.DataAnnotations;

namespace MakeAList.Models
{
    public class ListItem
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = "";

        public string? Url { get; set; }
        public bool IsDone { get; set; }

        public int UserListId { get; set; }
        public UserList? UserList { get; set; }
    }
}
