using System.Numerics;
using UnityEngine;

public class ShopManager : SingletoneBase<ShopManager>
{
    



    public void BuyUpgrade(int upgradeLevelData)
    {
        if (DataManager.Instance.money > getPrice(DataManager.UpgradeLevelDb.Get(upgradeLevelData)))
        {
            DataManager.Instance.money -= getPrice(DataManager.UpgradeLevelDb.Get(upgradeLevelData));
            UpdateDamageStat();
        }
            
    }

    private void UpdateDamageStat()
    {
        
    }

    private int getPrice(UpgradeLevelData upgradeLevelData)
    {
        return (int)(upgradeLevelData.initialPrice * Mathf.Pow(upgradeLevelData.priceMultiplier, upgradeLevelData.level));
    }

    private void CalculateNormalUpgrae()
    {
        
    }
    //private BigInteger getPrice(UpgradeLevelData upgradeLevelData)
    //{
    //    BigInteger price = (BigInteger)upgradeLevelData.initialPrice * BigInteger.Pow((int)(upgradeLevelData.priceMultiplier * 10), upgradeLevelData.level) / BigInteger.Pow(10, upgradeLevelData.level);
    //    return price;
    //}
}