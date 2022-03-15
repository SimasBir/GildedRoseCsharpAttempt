using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

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
            Assert.Equal(sellIn, Items[0].SellIn);
            Assert.Equal(quality, Items[0].Quality);
        }
        [Fact]
        public void UpdateQuality_AfterSellIn_LowerQualityBy4()
        {
            Items[0].SellIn = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 16;
            Assert.Equal(sellIn, Items[0].SellIn);
            Assert.Equal(quality, Items[0].Quality);
        }
        [Fact]
        public void UpdateQuality_AfterQuality0_NoQualityChange()
        {
            Items[0].Quality = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = 9;
            var quality = 0;
            Assert.Equal(sellIn, Items[0].SellIn);
            Assert.Equal(quality, Items[0].Quality);
        }        
    }
}
