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
        data = TimeLineData.instance;
    }

    // 外部修改时间线  自动同步到全局数据
    public void ChangeTimeLine(int newchapter)
    {
        // 存到全局数据
        data.chapter = newchapter;
        UpdataThings(newchapter);
    }

    public NPC_Visible GetNPCByName(string npcName)
    {
        for (int i = 0; i < data.npcs.Length; i++)
        {
            if (data.npcs[i] != null && data.npcs[i].gameObject.name == npcName)
            {
                return data.npcs[i];
            }
        }
        Debug.LogWarning("未找到NPC：" + npcName);
        return null;
    }
    // 修改周目
    public void ChangePlayThrough(int newPlayThrough)
    {
        data.playThrough = newPlayThrough;
    }
    //修改时间线中所有设置
    void UpdataThings(int newchapter)
    {
        int tl = newchapter;

        switch (tl)
        {
            case 112:
                //玩家对话取消
                data.playerIsOnDL = false;
                //
                //data.npcs[0].GetComponent<NPC_Dial>().dialogueData = data.diaSoOs[data.diaC
                break;
            case 113:
                data.diaCode = 16;
                data.playerIsOnDL =true;
                break;
            case 114:
                data.playerIsOnDL = false;
                data.diaCode = 19;
                GetNPCByName("Dad_Home").GetComponent<NPC_Dial>().isonline = true;
                GetNPCByName("Dad_Home").GetComponent<NPC_Dial>().dialogueData = data.diaSoOs[data.diaCode];
                break;
            case 115:
                GetNPCByName("Dad_Home").GetComponent<NPC_Dial>().isonline = false;
                break;
            default:
                break;
        }
    }
}
