using MakeAList.Controllers;
using MakeAList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeAList.Tests
{
    public class DeleteTests
    {
        [Fact]
        public async Task Delete_RemovesItem()
        {
            var context = TestDbContextFactory.Create();

            var item = new ListItem { Text = "Delete me" };
            context.ListItems.Add(item);
            context.SaveChanges();

            var controller = new ListItemsController(context);

            await controller.DeleteConfirmed(item.Id);

            Assert.Empty(context.ListItems);
        }

    }
}
