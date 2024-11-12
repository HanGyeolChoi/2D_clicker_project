
using UnityEngine;

public enum UpgradeType
{
    Click,
    Auto
}

public class UpgradeData : DataModel
{
    
    public string name;
    public UpgradeType type;
    public string spritePath;
    public float damage;

    public UpgradeData(int upgradeID, string name, UpgradeType type, float damage, string spritePath)
    {
        this.id = upgradeID;
        this.name = name;
        this.type = type;
        this.damage = damage;
        this.spritePath = spritePath;
    }
}
