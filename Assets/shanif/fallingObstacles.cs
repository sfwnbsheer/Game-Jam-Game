using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public int damage = 1;

    private Rigidbody2D rb;
    private Vector3 startPos;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb.gravityScale = 0;
    }

    public void Fall()
    {
        if (hasFallen) return;

        hasFallen = true;
        rb.gravityScale = 4; // start falling
    }

  
}

