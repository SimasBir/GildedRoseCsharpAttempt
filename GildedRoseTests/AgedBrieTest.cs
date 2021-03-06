using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests
{
    public class AgedBrieTest
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
        [Fact]
        public void UpdateQuality_BeforeSellIn_RaiseQualityBy1()
        {            
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 9;
            var quality = 21;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }

        [Fact]
        public void UpdateQuality_AfterSellIn_RaiseQualityBy2()
        {
            Items[0].SellIn = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 22;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }

        [Fact]
        public void UpdateQuality_AfterSellIn_RaiseQualityBy2Limit50()
        {
            Items[0].SellIn = 0;
            Items[0].Quality = 49;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 50;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }

        [Fact]
        public void UpdateQuality_AfterQuality50_NoQualityChange()
        {
            Items[0].SellIn = -5;
            Items[0].Quality = 50;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -6;
            var quality = 50;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }        
    }
}
