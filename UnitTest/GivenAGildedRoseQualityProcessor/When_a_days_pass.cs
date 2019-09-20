using System.Linq;
using csharp;
using FluentAssertions;
using Xunit;

namespace UnitTest.GivenAGildedRoseQualityProcessor
{
    public class When_days_pass : GivenAGildedRoseQualityProcessor
    {
        [Fact]
        public void It_should_drop_value_by_each_day()
        {
            for (var i = 0; i < 30; i++)
            {
                //GildedRoseQualityProcessor.UpdateQuality();
            }

            var item = Items.Single(x => x.ItemType == ItemType.DexterityVerst);

            item.Quality.Should().Be(0);
        }

        //[Fact]
        //public void blabla()
        //{
        //    GildedRoseTest()
        //}


    }
}
