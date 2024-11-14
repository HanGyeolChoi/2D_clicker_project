
using System.Collections.Generic;
using Unity.VisualScripting;
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
        foreach(UIItemSlot slot in slotList)
        {
            slotPool.Push(slot);
            slot.gameObject.SetActive(false);
        }
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
            slot.OnClickAction += ShopManager.Instance.BuyUpgrade;

            slot.gameObject.SetActive(true);
            slot.transform.SetAsLastSibling();

            slotList.Add(slot);
        }
    }


}