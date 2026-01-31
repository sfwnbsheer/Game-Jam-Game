using UnityEngine;
using TarodevController;

public class MaskCollect : MonoBehaviour
{
    public string maskName; // "Hanuman_Mask", "Agni_Mask", "Theyyam_Mask"

    [Header("Agni Mask Ability")]
    public float agniJumpMultiplier = 1.5f; // extra jump ONLY for Agni

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Transform player = other.transform;
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller == null) return;

        // Always reset jump when switching masks
        controller.ResetJumpMultiplier();

        // Handle mask visuals
        foreach (Transform child in player)
        {
            if (child.name.Contains("_Mask"))
                child.gameObject.SetActive(false);

            if (child.name == maskName)
                child.gameObject.SetActive(true);
        }

        // Apply Agni ability ONLY
        if (maskName == "Agni_Mask")
        {
            controller.SetJumpMultiplier(agniJumpMultiplier);
        }

        // Remove platform mask
        gameObject.SetActive(false);
    }
}
