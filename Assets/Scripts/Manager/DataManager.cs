

using System.Collections.Generic;

public class DataManager : SingletoneBase<DataManager>
{
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

    private DataBase<UpgradeLevelData> levelDb;
    public DataBase<UpgradeLevelData> LevelDb
    {
        get
        {
            if (Instance.levelDb == null)
            {
                List<UpgradeLevelData> tempList = new List<UpgradeLevelData>();
                // tempList = read levelDB.json file
                // 

                Instance.levelDb = new DataBase<UpgradeLevelData>(tempList);
            }



            return Instance.levelDb;
        }
    }


}