using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests
{
    public class ConjuredTest
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 20 } };
        
        [Fact]
        public void UpdateQuality_BeforeSellIn_LowerQualityBy2()
        {            
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 9;
            var quality = 18;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_AfterSellIn_LowerQualityBy4()
        {
            Items[0].SellIn = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 16;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }
        [Fact]
        public void UpdateQuality_AfterQuality0_NoQualityChange()
        {
            Items[0].Quality = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 9;
            var quality = 0;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);
        }        
    }
}
