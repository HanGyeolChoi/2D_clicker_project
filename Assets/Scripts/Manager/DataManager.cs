

using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletoneBase<DataManager>
{
    private string dataPath = $"{Application.dataPath}/Data/";

    private DataBase<UpgradeData> upgradeDb;
    public DataBase<UpgradeData> UpgradeDb
    {
        get
        {
            if(Instance.upgradeDb == null)
            {
                List<UpgradeData> tempList = new List<UpgradeData>();
                // tempList = read upgradeDB.json file
                // 

                Instance.upgradeDb = new DataBase<UpgradeData>(tempList);
            }

            

            return Instance.upgradeDb;
        }
    }

    private DataBase<UpgradeLevelData> upgradeLevelDb;
    public DataBase<UpgradeLevelData> UpgradeLevelDb
    {
        get
        {
            if (Instance.upgradeLevelDb == null)
            {
                List<UpgradeLevelData> tempList = new List<UpgradeLevelData>();
                // tempList = read levelDB.json file
                // 

                Instance.upgradeLevelDb = new DataBase<UpgradeLevelData>(tempList);
            }



            return Instance.upgradeLevelDb;
        }
    }

    private DataBase<SpecialUpgradeData> specialUpgradeLevelDb;
    public DataBase<SpecialUpgradeData> SpecialUpgradeLevelDb
    {
        get
        {
            if (Instance.specialUpgradeLevelDb == null)
            {
                List<SpecialUpgradeData> tempList = new List<SpecialUpgradeData>();
                // tempList = read levelDB.json file
                // 

                Instance.specialUpgradeLevelDb = new DataBase<SpecialUpgradeData>(tempList);
            }



            return Instance.specialUpgradeLevelDb;
        }
    }

}