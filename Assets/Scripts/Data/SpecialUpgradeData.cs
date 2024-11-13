public class SpecialUpgradeData : DataModel
{
    public string name;
    public string description;
    public int upgradeId;       // ��� �⺻ ���׷��̵忡 �ۿ��ϴ� ��
    public float multiplier;    // ���

    SpecialUpgradeData(int id, string name, string description, int upgradeId, float multiplier)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.upgradeId = upgradeId;
        this.multiplier = multiplier;
    }
}