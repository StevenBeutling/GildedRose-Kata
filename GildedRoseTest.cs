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
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseQualityProcessor app = new GildedRoseQualityProcessor(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }
    }
}
