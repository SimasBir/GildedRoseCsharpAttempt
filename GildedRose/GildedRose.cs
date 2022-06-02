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
                case < 0:
                    item.Quality = 0;
                    break;
                case < 5:
                    int qualityChange = item.Quality + 3;
                    item.Quality = QualityLimit(qualityChange);
                    break;
                case < 10:
                    qualityChange = item.Quality + 2;
                    item.Quality = QualityLimit(qualityChange);
                    break;
                default:
                    qualityChange = item.Quality + 1;
                    item.Quality = QualityLimit(qualityChange);
                    break;
            }
        }
    }
}
