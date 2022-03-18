using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests
{
    public class NormalItemTest
    {
        //IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        IList<Item> Items = new List<Item> { new Item { Name = "Not a special item name", SellIn = 10, Quality = 20 } };
        
        [Fact]
        public void UpdateQuality_BeforeSellIn_LowerQualityBy1()
        {            
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            var sellIn = 9;
            var quality = 19;

            Items[0].SellIn.Should().Be(sellIn);
            Items[0].Quality.Should().Be(quality);

            //Assert.Equal(sellIn, Items[0].SellIn);
            //Assert.Equal(quality, Items[0].Quality);
        }
        [Fact]
        public void UpdateQuality_AfterSellIn_LowerQualityBy2()
        {
            Items[0].SellIn = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 18;

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
