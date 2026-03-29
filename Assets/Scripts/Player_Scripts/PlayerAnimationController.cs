using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer; // 用于翻转角色朝向

    // 动画参数名称
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    void Awake()
    {
        // 获取组件
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>(); // 获取Sprite
    }

    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        // 检测水平/垂直方向输入（WASD / 方向键）
        float moveInput = Input.GetAxisRaw("Horizontal");
        float moveInput_v = Input.GetAxisRaw("Vertical");

        // 判断是否在移动
        bool isMoving = Mathf.Abs(moveInput) > 0.1f || Mathf.Abs(moveInput_v) > 0.1f;

        // 设置动画
        _animator.SetBool(IsMoving, isMoving);

        // ==============================================
        // 【新增】角色朝向翻转（左右）
        // ==============================================
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            // 水平输入 > 0 朝右；< 0 朝左
            _spriteRenderer.flipX = moveInput < 0;
        }
    }

    /// <summary>
    /// 触发退出动画
    /// </summary>
    public void TriggerExitAnimation()
    {
        _animator.SetTrigger("Exit");
    }
}