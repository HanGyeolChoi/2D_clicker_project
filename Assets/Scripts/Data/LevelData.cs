public class LevelData : DataModel
{
    public int upgradeID;
    public int level;
    public int initialPrice;

    LevelData(int id, int upgradeID, int level, int initialPrice)
    {
        this.id = id;
        this.upgradeID = upgradeID;
        this.level = level;
        this.initialPrice = initialPrice;
    }
}