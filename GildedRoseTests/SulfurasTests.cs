using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class SulfurasTest
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

        [Fact]
        public void UpdateQuality_Sulfuras_ShowNoChange()
        {
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var sellIn = 0;
            var quality = 80;
            Assert.Equal(sellIn, Items[0].SellIn);
            Assert.Equal(quality, Items[0].Quality);
        }
        [Fact]
        public void UpdateQuality_SulfurasPassSellIn_ShowNoChange()
        {
            Items[0].SellIn = -10;
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var sellIn = -10;
            var quality = 80;
            Assert.Equal(sellIn, Items[0].SellIn);
            Assert.Equal(quality, Items[0].Quality);
        }
    }
}
