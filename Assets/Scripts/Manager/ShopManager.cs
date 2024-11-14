using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ShopManager : SingletoneBase<ShopManager>
{
    List<float> UpgradeDamageList = new List<float>();


    public void BuyUpgrade(int upgradeLevelData)
    {
        if (DataManager.Instance.money > getPrice(DataManager.UpgradeLevelDb.Get(upgradeLevelData)))
        {
            DataManager.Instance.money -= getPrice(DataManager.UpgradeLevelDb.Get(upgradeLevelData));
            DataManager.UpgradeLevelDb.Get(upgradeLevelData).level++;
            UpdateDamageStat();
        }
            
    }

    private void UpdateDamageStat()
    {
        int id = 3001;  // normal upgrade
        while (DataManager.UpgradeLevelDb.isExist(id))
        {
            UpgradeDamageList.Add(DataManager.UpgradeLevelDb.Get(id).level);
            id++;
        }

        id = 4001;      //special upgrade 
        while (DataManager.UpgradeLevelDb.isExist(id))
        {
            if (DataManager.UpgradeLevelDb.Get(id).level > 0)
            {
                int upgradeId = DataManager.UpgradeLevelDb.Get(id).upgradeId;
                int index = DataManager.SpecialUpgradeDb.Get(upgradeId).upgradeId - 1001;
                UpgradeDamageList[index] *= DataManager.SpecialUpgradeDb.Get(upgradeId).multiplier * DataManager.UpgradeLevelDb.Get(id).level;
            }
            id++;
        }

        id = 1001;
        DataManager.Instance.clickDamage = (int)UpgradeDamageList[id - 1001];
        id = 1002;
        while (DataManager.UpgradeDb.isExist(id))
        {
            DataManager.Instance.autoDamage = (int)UpgradeDamageList[id - 1001];
            id++;
        }

    }

    private int getPrice(UpgradeLevelData upgradeLevelData)
    {
        return (int)(upgradeLevelData.initialPrice * Mathf.Pow(upgradeLevelData.priceMultiplier, upgradeLevelData.level));
    }


    //private BigInteger getPrice(UpgradeLevelData upgradeLevelData)
    //{
    //    BigInteger price = (BigInteger)upgradeLevelData.initialPrice * BigInteger.Pow((int)(upgradeLevelData.priceMultiplier * 10), upgradeLevelData.level) / BigInteger.Pow(10, upgradeLevelData.level);
    //    return price;
    //}
}