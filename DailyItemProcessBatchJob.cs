namespace csharp
{
    public interface IDailyItemProcessBatchJob
    {
        void Run();
    }

    public class DailyItemProcessBatchJob : IDailyItemProcessBatchJob
    {
        private readonly IGildedRoseStateService _gildedRoseStateService;
        private readonly IGildedRoseQualityUpdater _gildedRoseQualityUpdater;
        public DailyItemProcessBatchJob(IGildedRoseStateService gildedRoseStateService, IGildedRoseQualityUpdater gildedRoseQualityUpdater)
        {
            _gildedRoseStateService = gildedRoseStateService;
            _gildedRoseQualityUpdater = gildedRoseQualityUpdater;
        }
        public void Run()
        {
            var items = _gildedRoseStateService.GetGildedRoseItems();
            foreach (var item in items)
            {
                _gildedRoseQualityUpdater.UpdateQuality(item);
            }
        }
    }
}