using System.Collections.Generic;
using UnityEngine;

// 负责UI、添加物品、刷新逻辑，可挂载
public class InventoryManager : MonoBehaviour
{
    [Header("背包UI格子")]
    public InventorySlot[] itemSlots;

    // 全局数据
    private InventoryData data;

    private void Start()
    {
        // 拿到全局数据
        data = InventoryData.instance;

        // 刷新UI
        RefreshAllUI();
    }

    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }

    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }

    // 添加物品（修改全局数据）
    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (data == null) return;

        //  存在全局数据里
        data.myItemSOs.Add(itemSO);

        // 放到UI格子
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == null)
            {
                slot.itemSO = itemSO;
                slot.quantity = quantity;
                slot.UpdataUI();
                Debug.Log("物品已添加到全局背包");
                return;
            }
        }
    }

    // 刷新所有UI
    public void RefreshAllUI()
    {
        foreach (var slot in itemSlots)
        {
            slot.UpdataUI();
        }
    }
}

