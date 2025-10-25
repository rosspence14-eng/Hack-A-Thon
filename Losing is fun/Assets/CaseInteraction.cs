using UnityEngine;

public class CaseInteraction : MonoBehaviour, IInteractable
{
    [Header("Broken Case Settings")]
    public Sprite brokenSprite;
    public Vector3 brokenScale = Vector3.one;
    public Vector3 brokenOffset = Vector3.zero;

    private bool isBroken = false;

    public void Interact()
    {
        if (isBroken) return;
        isBroken = true;

        // ✅ Increase chaos score by 2
        if (AlarmManager.Instance != null)
        {
            AlarmManager.Instance.AddChaos();
            AlarmManager.Instance.AddChaos(); // Call twice to add 2
        }
        else
        {
            Debug.LogWarning("AlarmManager instance not found!");
        }

        // ✅ Swap sprite, scale, and position
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            if (brokenSprite != null)
                sr.sprite = brokenSprite;

            transform.localScale = brokenScale;
            transform.localPosition += brokenOffset;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer not found on this case.");
        }

        Debug.Log("Display case broken!");
    }
}