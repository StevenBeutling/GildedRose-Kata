namespace csharp
{
    public interface IGildedRoseQualityUpdater
    {
        void UpdateQuality(IItem item);
    }

    public class GildedRoseQualityUpdater : IGildedRoseQualityUpdater
    {
        private readonly IGildedRoseStateService _gildedRoseStateService;

        public GildedRoseQualityUpdater(IGildedRoseStateService gildedRoseStateService)
        {
            _gildedRoseStateService = gildedRoseStateService;
        }

        public void UpdateQuality(IItem item)
        {
            if (item.IsUnchangeable)
                return;

            if (item.ItemType != ItemType.AgedBrie && item.ItemType != ItemType.BackstagePassesTAFKAL80ETCConcert)
            {
                if (item.Quality > 0)
                {
                    _gildedRoseStateService.UpdateQuality(item.Id, -1);
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    _gildedRoseStateService.UpdateQuality(item.Id, 1);

                    if (item.ItemType == ItemType.BackstagePassesTAFKAL80ETCConcert)
                    {
                    
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                _gildedRoseStateService.UpdateQuality(item.Id, 1);
                            }
                            
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                _gildedRoseStateService.UpdateQuality(item.Id, 1);
                            }
                        }
                    }
                }
            }

            _gildedRoseStateService.DecreaseSellIn(item.Id);
            
            if (item.SellIn < 0)
            {
                if (item.ItemType != ItemType.AgedBrie)
                {
                    if (item.ItemType != ItemType.BackstagePassesTAFKAL80ETCConcert)
                    {
                        if (item.Quality > 0)
                        {
                            _gildedRoseStateService.UpdateQuality(item.Id, -1);
                        }
                    }
                    else
                    {
                        _gildedRoseStateService.UpdateQualityToZero(item.Id);
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        _gildedRoseStateService.UpdateQuality(item.Id, 1);
                    }
                }
            }

            if (item.IsConjured)
            {
                if (item.Quality > 0)
                {
                    _gildedRoseStateService.UpdateQuality(item.Id, -1);
                }
            }
        }
    }
}
