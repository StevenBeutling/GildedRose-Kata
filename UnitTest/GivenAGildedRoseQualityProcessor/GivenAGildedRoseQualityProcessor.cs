using System.Collections.Generic;
using csharp;

namespace UnitTest.GivenAGildedRoseQualityProcessor
{
    public class GivenAGildedRoseQualityProcessor
    {
        //protected readonly GildedRoseQualityProcessor GildedRoseQualityProcessor;
        protected IList<Item> Items;

        public GivenAGildedRoseQualityProcessor()
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "It_should_drop_value_by_each_day",
                    ItemType = ItemType.DexterityVerst,
                    Quality = 5,
                    SellIn = 5
                }
            };
            //GildedRoseQualityProcessor = new GildedRoseQualityProcessor(Items);
        }
    }
}