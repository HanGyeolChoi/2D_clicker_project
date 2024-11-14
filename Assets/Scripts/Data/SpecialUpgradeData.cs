public class SpecialUpgradeData : DataModel
{
    public string name;
    public string description;
    public int upgradeId;       // ��� �⺻ ���׷��̵忡 �ۿ��ϴ� ��
    public float multiplier;    // ���
    public string spritePath;

    public SpecialUpgradeData(int id, string name, string description, int upgradeId, float multiplier, string spritePath)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.upgradeId = upgradeId;
        this.multiplier = multiplier;
        this.spritePath = spritePath;
    }
}