using System;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private Image imgIcon;

    [SerializeField] private TMP_Text txtUpgradeName;
    [SerializeField] private TMP_Text txtUpgradeDescription;
    [SerializeField] private TMP_Text txtUpgradePrice;
    [SerializeField] private TMP_Text txtLevel;

    [SerializeField] private Button btnBuy;

    private UpgradeLevelData upgradeLevelData;

    public event Action<int> OnClickAction;

    private string spritePath = "Sprites/";
    public void SetData(UpgradeLevelData upgradeLevelData)
    {
        this.upgradeLevelData = upgradeLevelData;

        if (upgradeLevelData.upgradeId < 2000)
        {
            var item = DataManager.UpgradeDb.Get(upgradeLevelData.upgradeId);



            txtUpgradeName.text = item.name;
            txtUpgradeDescription.text = item.description;
            txtLevel.text = "Lv. " + upgradeLevelData.level.ToString();
            // BigInteger price = getPrice(upgradeLevelData);
            int price = getPrice(upgradeLevelData);
            txtUpgradePrice.text = $"{price} G";

            var sprite = Resources.Load<Sprite>($"{spritePath + item.spritePath}");
            imgIcon.sprite = sprite;
        }

        else //if (upgradeLevelData.upgradeId >= 2000)
        {
            var item = DataManager.SpecialUpgradeDb.Get(upgradeLevelData.upgradeId);



            txtUpgradeName.text = item.name;
            txtUpgradeDescription.text = item.description;
            txtLevel.text = "Lv. " + upgradeLevelData.level.ToString();
            // BigInteger price = getPrice(upgradeLevelData);
            int price = getPrice(upgradeLevelData);
            txtUpgradePrice.text = $"{price} G";

            var sprite = Resources.Load<Sprite>($"{spritePath + item.spritePath}");
            imgIcon.sprite = sprite;
        }


        btnBuy.onClick.AddListener(CallClickAction);
    }

    private int getPrice(UpgradeLevelData upgradeLevelData)
    {
        return (int)(upgradeLevelData.initialPrice * Mathf.Pow(upgradeLevelData.priceMultiplier, upgradeLevelData.level));
    }

    //private BigInteger getPrice(UpgradeLevelData upgradeLevelData)
    //{
    //    BigInteger price = (BigInteger)upgradeLevelData.initialPrice * BigInteger.Pow((int)(upgradeLevelData.priceMultiplier * 10), upgradeLevelData.level) / BigInteger.Pow(10, upgradeLevelData.level);
    //    return price;
    //}

    private void CallClickAction()
    {
        OnClickAction?.Invoke(upgradeLevelData.id);
    }


}