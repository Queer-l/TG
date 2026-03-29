using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (TimeLineData.instance.needSet)
        {
            Debug.Log(TimeLineData.instance.needSet);
            transform.position = TimeLineData.instance.plPosition;
            rb.velocity = Vector2.zero;
            TimeLineData.instance.needSet = false;
        }
    }

    // 输入检测 放在 Update
    private float x, y;
    void Update()
    {
        // 只获取输入，不处理物理
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    // 物理移动 必须放在 FixedUpdate
    void FixedUpdate()
    {
            // 正常玩家移动
            Vector2 moveDir = new Vector2(x, y).normalized;
            rb.velocity = moveDir * moveSpeed;
    }
}
