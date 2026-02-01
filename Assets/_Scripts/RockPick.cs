using TarodevController;
using UnityEngine;

public class RockPick : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rockRB;

    private void Awake()
    {
        rockRB.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        if (controller == null) return;

        if (controller.hasStrength && Mathf.Abs(controller.FrameInput.x) > 0.1f)
        {
            rockRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            controller.isPushing = true;
        }
        else
        {
            controller.isPushing = false;
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerController controller = other.gameObject.GetComponent<PlayerController>();
        if (controller != null)
            controller.isPushing = false;
    }
}
