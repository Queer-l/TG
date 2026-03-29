using UnityEngine;

// 全局唯一 时间线数据
public class TimeLineData : MonoBehaviour
{
    public static TimeLineData instance;

    // 所有全局数据存在这里
    public int playThrough = 1;
    public int chapter = 111;
    

    
    public NPC_DialogueSO[] diaSoOs;


    [Header("npc对话管理器")]
    public NPC_Dial[] npcs;

    [Header("玩家对话管理器")]
    public Player_DLManager[] playDLs;
    public bool playerIsOnDL = true;
    [Header("对话编码")]
    public int diaCode = 0;

    [Header("连接背包")]
    public InventoryManager itManager;

    [Header("传送位置")]
    public Vector3 plPosition;
    public bool needSet = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
