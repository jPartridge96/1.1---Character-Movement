public class Item
{
    public int Id { get; set; }
	public string Name { get; set; }
	public float BuyPrice { get; set; }

    public Item (int id, string name, float buyPrice) 
    {
        Id = id;
        Name = name;
        BuyPrice = buyPrice;
    }
}