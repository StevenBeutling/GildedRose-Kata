using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            new ContainerInstaller().Install(container, new DefaultConfigurationStore());



            Console.WriteLine("OMGHAI!");
            
            var items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, ItemType = ItemType.DexterityVerst},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0, ItemType = ItemType.AgedBrie},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, ItemType = ItemType.ElixirOfTheMongoose},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, ItemType = ItemType.SulfurasHandOfRagnaros},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, ItemType = ItemType.SulfurasHandOfRagnaros},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20, ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49, ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49, ItemType = ItemType.BackstagePassesTAFKAL80ETCConcert
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, ItemType = ItemType.ConjuredManaCace}
            };

            var app = new GildedRoseQualityProcessor(items);

            var batch = container.Resolve<IDailyItemProcessBatchJob>();
            var gildedRoseStateService = container.Resolve<IGildedRoseStateService>();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    Console.WriteLine(items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                var itemsFromService = gildedRoseStateService.GetGildedRoseItems();

                foreach (var item in itemsFromService)
                {
                    Console.WriteLine(item);
                }
                
                Console.WriteLine("");
                batch.Run();
            }

            Console.ReadKey();
        }
    }
}
