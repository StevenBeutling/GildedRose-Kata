using System;

namespace csharp
{
    public interface IItem
    {
        Guid Id { get; }
        string Name { get; }
        int SellIn { get; }
        int Quality { get; }
        ItemType ItemType { get; }
        bool IsConjured { get; }
        bool IsUnchangeable { get; }
        string ToString();
    }

    public class Item : IItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public ItemType ItemType { get; set; }
        public bool IsConjured => ItemType != ItemType.ConjuredManaCace;
        public bool IsUnchangeable => ItemType == ItemType.SulfurasHandOfRagnaros;
        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }  
    }

    public enum ItemType
    {
        DexterityVerst = 1,
        AgedBrie = 2,
        ElixirOfTheMongoose = 3,
        SulfurasHandOfRagnaros = 4,
        BackstagePassesTAFKAL80ETCConcert = 5,
        ConjuredManaCace = 6
    }

    public class ItemNames
    {
        public const string DexterityVerst = "+5 Dexterity Vest";
        public const string AgedBrie = "Aged Brie";
        public const string ElixirOfTheMongoose = "Elixir of the Mongoose";
        public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePassesTAFKAL80ETCConcert = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredManaCace = "Conjured Mana Cake";
    }
}
