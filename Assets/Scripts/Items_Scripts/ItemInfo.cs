using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemInfo : MonoBehaviour
{
    public CanvasGroup infoPanel;
    [Header("物品信息")]
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptipnText;
    public TMP_Text moreDescriptipnText;

    private RectTransform infoPanelRect;


    private void Awake()
    {
        infoPanelRect = GetComponent<RectTransform>();
    }

    public void ShowItemInfo(ItemSO itemSO)
    {
        infoPanel.alpha = 1;
        itemNameText.text = itemSO.itemName;
        itemDescriptipnText.text = itemSO.itemDescription;
        moreDescriptipnText.text = itemSO.moreDescription;
    }

    public void HideItemInfo()
    {
        infoPanel.alpha = 0;
        itemNameText.text = "";
        itemDescriptipnText.text = "";
        moreDescriptipnText.text = "";
    }

    public void FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 offset = new Vector3(10, -10, 0);

        infoPanelRect.position = mousePosition + offset;
    }
}
