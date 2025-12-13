using MakeAList.Controllers;
using MakeAList.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class ListItemsControllerTests
{
    [Fact]
    public async Task Create_AddsItemToDatabase()
    {
        var context = TestDbContextFactory.Create();
        var controller = new ListItemsController(context);

        var item = new ListItem
        {
            Text = "Test item",
            Url = "https://example.com",
            UserListId = 1
        };

        var result = await controller.Create(item);

        var savedItem = context.ListItems.First();
        Assert.Equal("Test item", savedItem.Text);
        Assert.Equal("https://example.com", savedItem.Url);
    }
}
