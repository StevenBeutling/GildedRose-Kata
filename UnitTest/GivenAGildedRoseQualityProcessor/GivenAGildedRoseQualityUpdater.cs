using System;
using csharp;
using Moq;

namespace UnitTest.GivenAGildedRoseQualityProcessor
{
    public class GivenAGildedRoseQualityUpdater
    {
        protected GildedRoseQualityUpdater GildedRoseQualityUpdater;
        protected Mock<IGildedRoseStateService> GildedRoseStateServiceMock;

        public GivenAGildedRoseQualityUpdater()
        {
            GildedRoseStateServiceMock = new Mock<IGildedRoseStateService>();
            GildedRoseQualityUpdater = new GildedRoseQualityUpdater(GildedRoseStateServiceMock.Object);
        }
    }
}