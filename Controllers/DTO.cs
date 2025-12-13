namespace MakeAList.Controllers
{
    public class DTO
    {
        public record IdDto(int Id);
        public record RenameDto(int Id, string Text);

    }
}
