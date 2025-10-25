using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DynamicSorting2D : MonoBehaviour
{
    public Transform targetToCompare; // Usually the player
    public float yOffset = 0f;        // Optional offset to tweak comparison

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (targetToCompare == null) return;

        float adjustedTargetY = targetToCompare.position.y + yOffset;

        // If this object is above the player, draw behind (lower order)
        // If below the player, draw in front (higher order)
        spriteRenderer.sortingOrder = transform.position.y > adjustedTargetY ? 0 : 2;
    }
}