

using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DataManager : SingletoneBase<DataManager>
{
    private DataBase<UpgradeData> upgradeDb;
    public static DataBase<UpgradeData> UpgradeDb
    {
        get
        {
            if(Instance.upgradeDb == null)
            {
                List<UpgradeData> tempList = new List<UpgradeData>()
                {
                    new UpgradeData(1001, "Ŭ�� ��ȭ", "Ŭ�� �������� 1 ������ŵ�ϴ�.", UpgradeType.Click, 1f, "ClickSprite"),
                    new UpgradeData(1002, "�⺻ ����", "�ʴ� �������� 1 ������ŵ�ϴ�.", UpgradeType.Auto, 1f, "FirstUpgradeSprite")
                };
                // TODO : tempList = read upgradeDB.json file
                // 

                Instance.upgradeDb = new DataBase<UpgradeData>(tempList);
            }

            

            return Instance.upgradeDb;
        }
    }

    private DataBase<SpecialUpgradeData> specialUpgradeLevelDb;
    public static DataBase<SpecialUpgradeData> SpecialUpgradeLevelDb
    {
        get
        {
            if (Instance.specialUpgradeLevelDb == null)
            {
                List<SpecialUpgradeData> tempList = new List<SpecialUpgradeData>()
                {
                    new SpecialUpgradeData(2001, "Ŭ�� ��� ��ȭ", "Ŭ�� �������� 25% ������ŵ�ϴ�.", 1001, 1.25f),
                    new SpecialUpgradeData(2002, "�⺻ ���� ��ȭ", "�⺻ ������ �������� 25% ������ŵ�ϴ�.", 1002, 1.25f),
                    new SpecialUpgradeData(2003, "�ڵ� Ŭ��", "5�ʸ��� �ѹ��� �ڵ����� Ŭ���մϴ�.", 1001, 1f)
                };
                // TODO: tempList = read SpecialUpgradeDB.json file
                // 

                Instance.specialUpgradeLevelDb = new DataBase<SpecialUpgradeData>(tempList);
            }



            return Instance.specialUpgradeLevelDb;
        }
    }

    private DataBase<UpgradeLevelData> upgradeLevelDb;
    public static DataBase<UpgradeLevelData> UpgradeLevelDb
    {
        get
        {
            if (Instance.upgradeLevelDb == null)
            {
                List<UpgradeLevelData> tempList = new List<UpgradeLevelData>()
                {
                    new UpgradeLevelData(3001, 1001, 1, 10, true, 1.1f),
                    new UpgradeLevelData(3002, 1002, 0, 20, false, 1.2f),
                    new UpgradeLevelData(4001, 2001, 0, 30, false, 3f),
                    new UpgradeLevelData(4002, 2002, 0, 100, false, 3f),
                    new UpgradeLevelData(4003, 2003, 0, 50, false, 5f)
                };
                // TODO : tempList = read UpgradeLevelDB.json file
                // 

                Instance.upgradeLevelDb = new DataBase<UpgradeLevelData>(tempList);
            }

            return Instance.upgradeLevelDb;
        }
    }

    private DataBase<ShopData> shopDb;
    public static DataBase<ShopData> ShopDb
    {
        get
        {
            if (Instance.shopDb == null)
            {
                List<ShopData> tempList = new List<ShopData>()
                {
                    new ShopData(5001, "Normal Shop", new List<int>{3001, 3002 }),
                    new ShopData(5002, "Special Shop", new List<int>{4001, 4002, 4003 })
                };
                // TODO : tempList = read ShopDB.json file
                // 

                Instance.shopDb = new DataBase<ShopData>(tempList);
            }

            return Instance.shopDb;
        }
    }

    //public BigInteger clickDamage;
    //public BigInteger autoDamage;
    public int clickDamage;
    public int autoDamage;
    public int maxStage;
    //public BigInteger money;
    public int money;
}