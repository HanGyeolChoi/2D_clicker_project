
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    [SerializeField] private UIItemSlot uiItemSlot;
    [SerializeField] private Button normalShopButton;
    [SerializeField] private Button specialShopButton;

    [SerializeField] private Transform contentRoot;

    private int normalShopCode = 5001;
    private int specialShopCode = 5002;

    private List<UIItemSlot> slotList = new List<UIItemSlot>();
    private Stack<UIItemSlot> slotPool = new Stack<UIItemSlot>();   // slot object pooling

    private void Start()
    {
        normalShopButton.onClick.AddListener(() => SetShop(normalShopCode));
        specialShopButton.onClick.AddListener(() => SetShop(specialShopCode));

        SetShop(normalShopCode);
    }
    public void SetShop(int shopId)
    {
        ShopData shopData = DataManager.ShopDb.Get(shopId);

        List<int> upgradeLevelList = shopData.upgradeLevelList;
        foreach (int upgradeLevelId in upgradeLevelList)
        {
            
            var upgradeLevel = DataManager.UpgradeLevelDb.Get(upgradeLevelId);

            UIItemSlot slot;

            if (slotPool.Count == 0)
                slot = Instantiate(uiItemSlot, contentRoot);
            else
                slot = slotPool.Pop();

            slot.SetData(upgradeLevel);
        }
    }


}