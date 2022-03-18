using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests
{
    public class BackstagePassTest
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20 } };
        [Fact]
        public void UpdateQuality_11DaysBeforeSellIn_RaiseQualityBy1()
        {
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 10;
            var quality = 21;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_10DaysBeforeSellIn_RaiseQualityBy2()
        {
            Items[0].SellIn = 10;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 9;
            var quality = 22;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_6DaysBeforeSellIn_RaiseQualityBy2()
        {
            Items[0].SellIn = 6;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 5;
            var quality = 22;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_5DaysBeforeSellIn_RaiseQualityBy3()
        {
            Items[0].SellIn = 5;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 4;
            var quality = 23;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_1DaysBeforeSellIn_RaiseQualityBy3()
        {
            Items[0].SellIn = 1;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 0;
            var quality = 23;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_1DaysBeforeSellIn_RaiseQualityBy3Limit50()
        {
            Items[0].SellIn = 1;
            Items[0].Quality = 48;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 0;
            var quality = 50;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_0DaysBeforeSellIn_DropQualityTo0()
        {
            Items[0].SellIn = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 0;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_AfterQuality50_NoQualityChange()
        {
            Items[0].SellIn = 2;
            Items[0].Quality = 50;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 1;
            var quality = 50;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
    }
}
