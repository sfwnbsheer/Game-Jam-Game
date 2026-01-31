using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol")]
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    [Header("Attack")]
    public float attackRange = 1.2f;
    public LayerMask playerLayer;
    public Transform raycastPoint; // empty object in front of enemy

    private Rigidbody2D rb;
    private Animator animator;
    private Transform player;

    private bool movingRight = true;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || isAttacking) return;

        if (PlayerInRange())
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        animator.SetBool("isAttacking", false);
        animator.SetFloat("speed", 1f);

        float moveDir = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);

        if (movingRight && transform.position.x >= rightPoint.position.x)
            Flip();
        else if (!movingRight && transform.position.x <= leftPoint.position.x)
            Flip();
    }

    void Attack()
    {
        isAttacking = true;
        rb.velocity = Vector2.zero;

        animator.SetBool("isAttacking", true);
        animator.SetFloat("speed", 0f);

        Debug.Log("Enemy attacking");
    }

    // Call this from Animation Event at END of attack animation
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }


    bool PlayerInRange()
    {
        float facingDir = transform.localScale.x > 0 ? 1f : -1f;

        RaycastHit2D hit = Physics2D.Raycast(
            raycastPoint.position,
            Vector2.right * facingDir,
            attackRange,
            playerLayer
        );

        if (hit.collider != null)
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            return true;
        }

        return false;
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
        if (raycastPoint == null) return;

        float facingDir = transform.localScale.x > 0 ? 1f : -1f;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            raycastPoint.position,
            raycastPoint.position + Vector3.right * facingDir * attackRange
        );
    }
}
