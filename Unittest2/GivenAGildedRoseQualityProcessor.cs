using System.Collections.Generic;
using System.Linq;
using csharp;
using Xunit;
using static Xunit.Assert;

namespace UnitTest2
{
    public class GivenAGildedRoseQualityProcessor
    {
        private readonly GildedRoseQualityProcessor _gildedRoseQualityProcessor;
        private readonly List<Item> _items;
        public GivenAGildedRoseQualityProcessor()
        {
            _items = new List<Item>
            {
                new Item
                {
                    Name = "blabla",
                    ItemType = ItemType.DexterityVerst,
                    Quality = 5,
                    SellIn = 5
                }
            };
            _gildedRoseQualityProcessor = new GildedRoseQualityProcessor(_items);
        }

        [Fact]
        public void blabla()
        {
            for (var i = 0; i < 30; i++)
            {
                _gildedRoseQualityProcessor.UpdateQuality();
            }

            var item = _items.Single(x => x.ItemType == ItemType.DexterityVerst);

            if (item != null) Equal(item.Quality, 0);
        }
    }
}
