using System.Collections.Generic;

public class ShopData : DataModel
{
    public string shopName;
    public List<int> upgradeLevelList;

    public ShopData(int id, string shopName, List<int> upgradeLevelList)
    {
        this.id = id;
        this.shopName = shopName;
        this.upgradeLevelList = upgradeLevelList;
    }
}