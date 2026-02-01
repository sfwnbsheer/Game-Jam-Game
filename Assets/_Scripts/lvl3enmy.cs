using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Patrol")]
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    [Header("Attack")]
    public float attackRange = 1.2f;
    public float attackCooldown = 1.2f;
    public LayerMask playerLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool movingRight = true;
    private float lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool playerClose = PlayerInTarget();

        if (playerClose && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    public void Follow()
    {
        animator.SetBool("isAttacking", false);
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        if (transform.position.x <= leftPoint.position.x)
            Flip();
    }

    void Attack()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("isAttacking", true);
        lastAttackTime = Time.time;
    }

    bool PlayerInTarget()
    {
        return Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }
    }
   
}   

