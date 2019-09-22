using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public interface IGildedRoseStateService
    {
        IEnumerable<IItem> GetGildedRoseItems();
        void UpdateQuality(Guid id, int qualityAddition);
        void UpdateQualityToZero(Guid id);
        void DecreaseSellIn(Guid id);
    }

    public class GildedRoseStateService : IGildedRoseStateService
    {
        private List<Item> _gildedRoseItems;

        public GildedRoseStateService()
        {
            _gildedRoseItems = new List<Item> {
                new Item {Id= Guid.NewGuid(), Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, ItemType = ItemType.DexterityVerst},
                new Item {Id= Guid.NewGuid(), Name = "Aged Brie", SellIn = 2, Quality = 0, ItemType = ItemType.AgedBrie},
                new Item {Id= Guid.NewGuid(), Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, ItemType = ItemType.ElixirOfTheMongoose},
                new Item {Id= Guid.NewGuid(), Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, ItemType = ItemType.SulfurasHandOfRagnaros},
                new Item {Id= Guid.NewGuid(), Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, ItemType = ItemType.SulfurasHandOfRagnaros},
                new Item
                {
                    Id= Guid.NewGuid(),
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20, ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert
                },
                new Item
                {
                    Id= Guid.NewGuid(),
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49, ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert
                },
                new Item
                {
                    Id= Guid.NewGuid(),
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49, ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert
                },
                // this conjured item does not work properly yet
                new Item {Id= Guid.NewGuid(), Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, ItemType = ItemType.ConjuredManaCace}
            };
        }

        public IEnumerable<IItem> GetGildedRoseItems()
        {
            return _gildedRoseItems;
        }

        public void UpdateQuality(Guid id, int qualityAddition)
        {
            var item = _gildedRoseItems.Single(x => x.Id == id);
            item.Quality += qualityAddition;
        }

        public void UpdateQualityToZero(Guid id)
        {
            var item = _gildedRoseItems.Single(x => x.Id == id);
            item.Quality = 0;
        }

        public void DecreaseSellIn(Guid id)
        {
            var item = _gildedRoseItems.Single(x => x.Id == id);
            item.SellIn--;
        }
    }
}