using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRoseQualityProcessor(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }
    }
}
