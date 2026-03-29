using System.Collections.Generic;
using UnityEngine;

// 负责执行逻辑、UI、对话管理
public class TimeLine_Manager : MonoBehaviour
{
    

    // 引用全局数据
    private TimeLineData data;
    private List<ItemSO> myItems;

    private void Start()
    {
        // 获取全局数据
        data = TimeLineData.instance;
    }

    private void Update()
    {
        // 实时获取背包
        myItems = InventoryData.instance.myItemSOs;
    }

    // 外部修改时间线  自动同步到全局数据
    public void ChangeTimeLine(int newchapter)
    {
        // 存到全局数据
        data.chapter = newchapter;
        

        UpdataThings(newchapter);
    }

    // 修改周目
    public void ChangePlayThrough(int newPlayThrough)
    {
        data.playThrough = newPlayThrough;
    }

    void UpdataThings(int newchapter)
    {
        int tl = newchapter;

        switch (tl)
        {
            case 112:
                data.playerIsOnDL = false;
                break;

            default:
                break;
        }
    }
}
