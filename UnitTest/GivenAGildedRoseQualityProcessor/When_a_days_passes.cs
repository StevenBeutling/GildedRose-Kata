using System;
using csharp;
using Moq;
using Xunit;

namespace UnitTest.GivenAGildedRoseQualityProcessor
{
    public class When_a_passes : GivenAGildedRoseQualityUpdater
    {
        [Theory,
           InlineData(ItemType.DexterityVerst),
           InlineData(ItemType.ElixirOfTheMongoose)]
        public void It_should_decrease_the_quantity_when_current_quality_is_above_0(ItemType itemType)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = 5,
                ItemType = itemType,
                SellIn = 20,
                Name = string.Empty
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.UpdateQuality(item.Id, -1), Times.Once);
        }

        [Theory,
         InlineData(ItemType.AgedBrie),
         InlineData(ItemType.BackstagePassesTAFKAL80ETCConcert)]
        public void It_should_increase_the_quality_when_current_quality_is_below_50(ItemType itemType)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = 49,
                ItemType = itemType,
                SellIn = 20,
                Name = string.Empty
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.UpdateQuality(item.Id, 1), Times.Once);
        }

        [Theory,
         InlineData(ItemType.SulfurasHandOfRagnaros)]
        public void It_should_never_update_the_quality(ItemType itemType)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = 40,
                ItemType = itemType,
                SellIn = 20,
                Name = string.Empty
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.UpdateQuality(item.Id, It.IsAny<int>()), Times.Never);
        }

        [Theory,
         InlineData(ItemType.ConjuredManaCace, ItemNames.ConjuredManaCace),
         InlineData(ItemType.DexterityVerst, ItemNames.DexterityVerst),
         InlineData(ItemType.ElixirOfTheMongoose, ItemNames.ElixirOfTheMongoose),
         InlineData(ItemType.AgedBrie, ItemNames.AgedBrie),
         InlineData(ItemType.BackstagePassesTAFKAL80ETCConcert, 
         ItemNames.BackstagePassesTAFKAL80ETCConcert)]
        public void It_should_decrease_SelIn(ItemType itemType, string name)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = 0,
                ItemType = itemType,
                SellIn = 0,
                Name = name
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.DecreaseSellIn(item.Id), Times.Once);
        }

        [Theory,
         InlineData(ItemType.SulfurasHandOfRagnaros, ItemNames.SulfurasHandOfRagnaros)]
        public void It_should_never_update_SelIn(ItemType itemType, string name)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = 40,
                ItemType = itemType,
                SellIn = 20,
                Name = name
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.DecreaseSellIn(item.Id), Times.Never);
        }

        [Theory,
          InlineData(20, 11, 1),
          InlineData(50, 11, 0),
          InlineData(20, 10, 2),
          InlineData(50, 10, 0),
          InlineData(20, 6, 2),
          InlineData(50, 6, 0),
          InlineData(20, 5, 3),
          InlineData(50, 5, 0)]
        public void It_should_update_quality_of_backstagepasses_Correctly(int quality, int sellIn, int qualityAdition)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = quality,
                ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert,
                SellIn = sellIn,
                Name = string.Empty
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.UpdateQuality(item.Id, 1), Times.Exactly(qualityAdition));
        }

        [Theory,
          InlineData(0, 0),
          InlineData(2, 2)]
        public void It_should_decrease_quality_of_conjured_items_correctly(int quality, int qualityDecrease)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = quality,
                ItemType = ItemType.ConjuredManaCace,
                SellIn = 20,
                Name = string.Empty
            };

            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.UpdateQuality(item.Id, -1), Times.Exactly(qualityDecrease));
        }

        [Fact]
        public void It_should_update_quality_to_zero_when_sellIn_is_smaller_then_0()
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Quality = 20,
                ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert,
                SellIn = -1,
                Name = ItemNames.BackstagePassesTAFKAL80ETCConcert
            };
            
            GildedRoseQualityUpdater.UpdateQuality(item);
            GildedRoseStateServiceMock.Verify(x => x.UpdateQualityToZero(item.Id), Times.Once);
        }
    }
}
