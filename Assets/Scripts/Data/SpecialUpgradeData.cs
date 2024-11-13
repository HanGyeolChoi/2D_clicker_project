public class SpecialUpgradeData : DataModel
{
    public string name;
    public string description;
    public int upgradeId;       // 어느 기본 업그레이드에 작용하는 지
    public float multiplier;    // 배수

    SpecialUpgradeData(int id, string name, string description, int upgradeId, float multiplier)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.upgradeId = upgradeId;
        this.multiplier = multiplier;
    }
}