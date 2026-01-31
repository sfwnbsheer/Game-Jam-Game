using UnityEngine;

public class MaskCollect : MonoBehaviour
{
    public string maskName; // "Hanuman_Mask", "Agni_Mask", "Theyyam_Mask"

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Get all masks from player
        Transform player = other.transform;

        foreach (Transform child in player)
        {
            // Turn OFF all masks
            if (child.name.Contains("_Mask"))
            {
                child.gameObject.SetActive(false);
            }

            // Turn ON the collected mask
            if (child.name == maskName)
            {
                child.gameObject.SetActive(true);
            }
        }

        // Remove platform mask
        gameObject.SetActive(false);
    }
}
