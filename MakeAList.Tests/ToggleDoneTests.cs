using MakeAList.Controllers;
using MakeAList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MakeAList.Controllers.DTO;

namespace MakeAList.Tests
{
    public class ToggleDoneTests
    {
        [Fact]
        public async Task ToggleDone_ChangesIsDoneValue()
        {
            var context = TestDbContextFactory.Create();

            var item = new ListItem
            {
                Text = "Checkbox test",
                IsDone = false
            };

            context.ListItems.Add(item);
            context.SaveChanges();

            var controller = new ListItemsController(context);

            await controller.ToggleDone(new IdDto(item.Id));

            var updated = context.ListItems.First();
            Assert.True(updated.IsDone);
        }

    }
}
