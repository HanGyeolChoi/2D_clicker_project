public class UpgradeLevelData : DataModel
{
    public int upgradeID;
    public int level;
    public int initialPrice;

    UpgradeLevelData(int id, int upgradeID, int level, int initialPrice)
    {
        this.id = id;
        this.upgradeID = upgradeID;
        this.level = level;
        this.initialPrice = initialPrice;
    }
}