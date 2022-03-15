using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality1()
        {
            foreach (Item item in Items)
            {
                var sellModifier = 1;
                //var qualityModifier = 1;
                if (item.SellIn <= 0)
                {
                    sellModifier = 2;
                }
                item.SellIn -= 1;
                switch (item.Name)
                {
                    case "Aged Brie":
                        item.Quality += 1 * sellModifier;
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":

                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        item.SellIn += 1;
                        break;
                    case "Conjured Mana Cake":
                        item.Quality -= 2 * sellModifier;
                        break;
                    default:
                        item.Quality -= 1 * sellModifier;
                        break;
                }
            }
        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            if (Items[i].Name.Contains("Conjured "))
                            {
                                Items[i].Quality = Items[i].Quality - 2;
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    if (Items[i].Name.Contains("Conjured "))
                                    {
                                        Items[i].Quality = Items[i].Quality - 2;
                                    }
                                    else
                                    {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
