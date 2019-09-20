namespace csharp
{
    public static class DailyItemProcessBatchJob
    {
        public static void Run()
        {
            var items = GildedRoseStateService.GetGildedRoseItems();
            foreach (var item in items)
            {
                GildedRoseQualityUpdater.UpdateQuality(item);
            }
        }
    }
}