using UnityEngine;
using TarodevController;

public class MaskCollect : MonoBehaviour
{
    public string maskName;

    [Header("Vamanan Mask Ability")]
    public float vamananJumpMultiplier = 1.5f;

    [Header("Hanuman Mask Ability")]
    public Rigidbody2D rockRb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerController controller = other.GetComponent<PlayerController>();
        Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

        if (controller == null || playerRb == null) return;

        // Reset player state
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        controller.ResetJumpMultiplier();
        controller.hasStrength = false; // reset first

        // Mask visuals
        foreach (Transform child in other.transform)
        {
            if (child.name.Contains("_Mask"))
                child.gameObject.SetActive(false);

            if (child.name == maskName)
                child.gameObject.SetActive(true);
        }

        // Mask-specific logic
        switch (maskName)
        {
            case "Vamanan_Mask":
                controller.SetJumpMultiplier(vamananJumpMultiplier);
                break;

            case "Hanuman_Mask":
                controller.hasStrength = true; //  ENABLE STRENGTH
                break;
        }

        gameObject.SetActive(false);
    }
}
