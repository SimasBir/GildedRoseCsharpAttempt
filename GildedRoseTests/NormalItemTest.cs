using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

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
            Assert.Equal(sellIn, Items[0].SellIn);
            Assert.Equal(quality, Items[0].Quality);
        }
        [Fact]
        public void UpdateQuality_AfterSellIn_LowerQualityBy2()
        {
            Items[0].SellIn = 0;

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var sellIn = -1;
            var quality = 18;
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
