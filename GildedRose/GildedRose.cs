using System;
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
        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                var lateSaleModifier = 1;
                if (item.SellIn <= 0)
                {
                    lateSaleModifier = 2;
                }
                item.SellIn--;

                switch (item.Name)
                {
                    case "Aged Brie":
                        int qualityChange = item.Quality + 1 * lateSaleModifier;                     
                        item.Quality = QualityLimit(qualityChange);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        BackstagePassQuality(item);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        item.SellIn++;
                        break;
                    case "Conjured Mana Cake":                        
                        qualityChange = item.Quality - 2 * lateSaleModifier;
                        item.Quality = QualityLimit(qualityChange);
                        break;
                    default:                        
                        qualityChange = item.Quality - 1 * lateSaleModifier;
                        item.Quality = QualityLimit(qualityChange);
                        break;
                }
            }
        }

        private int QualityLimit(int qualityChange)
        {
            return Math.Clamp(qualityChange, 0, 50);
        }

        private void BackstagePassQuality(Item item)
        {
            switch (item.SellIn)
            {
                case <0:
                    item.Quality = 0;
                    break;
                case <5:
                    int qualityChange = item.Quality + 3;
                    item.Quality = QualityLimit(qualityChange);
                    break;
                case <10:
                    qualityChange = item.Quality + 2;
                    item.Quality = QualityLimit(qualityChange);
                    break;
                default:
                    qualityChange = item.Quality + 1;
                    item.Quality = QualityLimit(qualityChange);
                    break;
            }
        }

        //public void UpdateQuality1()
        //{
        //    for (var i = 0; i < Items.Count; i++)
        //    {
        //        if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //        {
        //            if (Items[i].Quality > 0)
        //            {
        //                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                {
        //                    if (Items[i].Name.Contains("Conjured "))
        //                    {
        //                        Items[i].Quality = Items[i].Quality - 2;
        //                    }
        //                    else
        //                    {
        //                        Items[i].Quality = Items[i].Quality - 1;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (Items[i].Quality < 50)
        //            {
        //                Items[i].Quality = Items[i].Quality + 1;

        //                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //                {
        //                    if (Items[i].SellIn < 11)
        //                    {
        //                        if (Items[i].Quality < 50)
        //                        {
        //                            Items[i].Quality = Items[i].Quality + 1;
        //                        }
        //                    }

        //                    if (Items[i].SellIn < 6)
        //                    {
        //                        if (Items[i].Quality < 50)
        //                        {
        //                            Items[i].Quality = Items[i].Quality + 1;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //        {
        //            Items[i].SellIn = Items[i].SellIn - 1;
        //        }

        //        if (Items[i].SellIn < 0)
        //        {
        //            if (Items[i].Name != "Aged Brie")
        //            {
        //                if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //                {
        //                    if (Items[i].Quality > 0)
        //                    {
        //                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                        {
        //                            if (Items[i].Name.Contains("Conjured "))
        //                            {
        //                                Items[i].Quality = Items[i].Quality - 2;
        //                            }
        //                            else
        //                            {
        //                                Items[i].Quality = Items[i].Quality - 1;
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //                }
        //            }
        //            else
        //            {
        //                if (Items[i].Quality < 50)
        //                {
        //                    Items[i].Quality = Items[i].Quality + 1;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
