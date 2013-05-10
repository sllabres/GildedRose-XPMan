using System.Collections.Generic;

namespace XPManGildedRose
{
	class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items) 
		{
			this.Items = Items;
		}
		
		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
                if (IsLegendaryItem(Items[i].Name) == false && Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Quality > 0)
			    {
			        Items[i].Quality = Items[i].Quality - 1;
			    }
			    else
			    {
                    if (Items[i].Quality < 50 && IsLegendaryItem(Items[i].Name) == false)
			        {
			            Items[i].Quality = Items[i].Quality + 1;

			            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
			            {
			                if (Items[i].SellIn < 11 && Items[i].Quality < 50)
			                {
			                    Items[i].Quality = Items[i].Quality + 1;
			                }

			                if (Items[i].SellIn < 6 && Items[i].Quality < 50)
			                {
			                    Items[i].Quality = Items[i].Quality + 1;
			                }
			            }
			        }
			    }

                if (IsLegendaryItem(Items[i].Name) == false)
				    Items[i].SellIn = Items[i].SellIn - 1;

                if (Items[i].SellIn < 0 && IsLegendaryItem(Items[i].Name) == false)
				{
					if (Items[i].Name != "Aged Brie")
					{
					    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Quality > 0)
					    {
					        Items[i].Quality = Items[i].Quality - 1;
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

	    private bool IsLegendaryItem(string name)
	    {
	        return name == "Sulfuras, Hand of Ragnaros";
	    }
	}
	
	public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
