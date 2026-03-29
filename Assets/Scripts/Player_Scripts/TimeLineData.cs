using UnityEngine;

// 全局唯一 时间线数据
public class TimeLineData : MonoBehaviour
{
    public static TimeLineData instance;

    // 所有全局数据存在这里
    public int playThrough = 1;
    public int chapter = 111;


    [Header("对话内容存放")]
    public NPC_DialogueSO[] diaSoOs;
    [Header("npc管理器")]
    public NPC_Visible[] npcs = new NPC_Visible[40];
    
    public bool playerIsOnDL = true;
    [Header("对话编码")]
    public int diaCode = 0;
    [Header("CG图库")]
    public Sprite[] CGs;
    public int cgCode = 0;
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

            // 新增：监听场景切换
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // 场景加载完成 → 清空旧NPC数组
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        Debug.Log("新场景加载：清空旧NPC数据");
        ClearNPCArray();
    }

    /// <summary>
    /// 清空全局NPC数组，让新场景NPC重新注册
    /// </summary>
    public void ClearNPCArray()
    {
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i] = null;
        }
    }
}
