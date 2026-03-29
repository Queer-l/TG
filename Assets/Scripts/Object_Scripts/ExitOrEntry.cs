using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ExitOrEntry : MonoBehaviour
{
    [Header("目标场景名称")]
    public string sceneName = "UntitledScene";
    [Header("传送位置")]
    public Vector3 pltoPosition;
    [Header("解锁道具")]
    public ItemSO[] neededItems;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("2D 触发碰到：" + other.gameObject.name);
        if (InventoryData.instance != null)
        {
            Debug.Log("触发判断");
            foreach (var item in neededItems)
            {
                if (!InventoryData.instance.myItemSOs.Exists(e => e.itemName == item.itemName))
                {
                    return;
                }
            }
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("玩家碰到，开始跳转场景：" + sceneName);
            TimeLineData.instance.plPosition = pltoPosition;
            TimeLineData.instance.needSet = true;
            SceneManager.LoadScene(sceneName);
        }
    }
}
