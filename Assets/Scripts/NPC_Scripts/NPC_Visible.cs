using UnityEngine;

public class NPC_Visible : MonoBehaviour
{
    [Header("Position")]
    public Vector3 targetWorldPos;

    [Header("Visible")]
    public bool isCharacterVisible = true;

    private MonoBehaviour[] otherScripts;
    private Renderer[] renderers;

    // 关键修改：用 2D 碰撞体数组
    private Collider2D[] colliders2D;

    private void Start()
    {
        // 自动把自己注册到全局时间线数据里
        RegisterToGlobalTimeLine();
    }
    void Awake()
    {
        otherScripts = GetComponentsInChildren<MonoBehaviour>();
        renderers = GetComponentsInChildren<Renderer>();
        colliders2D = GetComponentsInChildren<Collider2D>();
    }

    void Update()
    {
        transform.position = targetWorldPos;
        SetCharacterVisible(isCharacterVisible);
    }

    void SetCharacterVisible(bool visible)
    {
        foreach (var script in otherScripts)
        {
            if (script != this)
                script.enabled = visible;
        }

        foreach (var col in colliders2D)
        {
            col.enabled = visible;
        }

        foreach (var render in renderers)
        {
            render.enabled = visible;
        }
    }
    public void SetTargetPosition(Vector3 newPos)
    {
        targetWorldPos = newPos;
        transform.position = newPos;
    }
    public void SetVisibleState(bool state)
    {
        isCharacterVisible = state;
    }

    void RegisterToGlobalTimeLine()
    {
        if (TimeLineData.instance == null)
        {
            Debug.LogError("全局 TimeLineData 不存在！请在初始场景放置它");
            return;
        }

        // 遍历数组，找到第一个空位置放自己
        for (int i = 0; i < TimeLineData.instance.npcs.Length; i++)
        {
            if (TimeLineData.instance.npcs[i] == null)
            {
                TimeLineData.instance.npcs[i] = this;
                Debug.Log(gameObject.name + " 已注册到全局NPC管理器，位置：" + i);
                break;
            }
        }
    }
}
