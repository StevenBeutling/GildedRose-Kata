namespace csharp
{
    public class GildedRoseQualityUpdater
    {
        public static void UpdateQuality(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        GildedRoseStateService.UpdateQuality(item.Id, -1);
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    //item.Quality = item.Quality + 1;
                    GildedRoseStateService.UpdateQuality(item.Id, 1);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                //item.Quality = item.Quality + 1;
                                GildedRoseStateService.UpdateQuality(item.Id, 1);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                //item.Quality = item.Quality + 1;
                                GildedRoseStateService.UpdateQuality(item.Id, 1);
                            }
                        }
                    }
                }
            }

            // Eruit getrokken
            UpdateSellIn(item);

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                //item.Quality = item.Quality - 1;
                                GildedRoseStateService.UpdateQuality(item.Id, -1);
                            }
                        }
                    }
                    else
                    {
                        //item.Quality = item.Quality - item.Quality;
                        GildedRoseStateService.UpdateQualityToZero(item.Id);
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        //item.Quality = item.Quality + 1;
                        GildedRoseStateService.UpdateQuality(item.Id, 1);
                    }
                }
            }
        }

        private static void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                //item.SellIn = item.SellIn - 1;
                GildedRoseStateService.UpdateSellIn(item.Id, -1);
            }
        }
    }
}
