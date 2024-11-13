public class UpgradeLevelData : DataModel
{
    public int upgradeId;
    public int level;
    public int initialPrice;
    public bool isUnlocked;
    public float priceMultiplier;
    public UpgradeLevelData(int id, int upgradeId, int level, int initialPrice, bool isUnlocked, float priceMultiplier)
    {
        this.id = id;
        this.upgradeId = upgradeId;
        this.level = level;
        this.initialPrice = initialPrice;
        this.isUnlocked = isUnlocked;
        this.priceMultiplier = priceMultiplier;
    }
}