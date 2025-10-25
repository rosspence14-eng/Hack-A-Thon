using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private GameObject pixelSceneRoot;         // Root of your pixel art scene
    [SerializeField] private RectTransform realisticImage;      // Full realistic image in UI
    [SerializeField] private RectTransform photoFrameMask;      // UI mask that acts as the photo frame
    [SerializeField] private Transform playerTransform;         // Your reporter character

    [Header("Image Settings")]
    [SerializeField] private float pixelsPerUnit = 100f;        // Adjust based on image scale

    private bool photoTaken = false;

    public void TakePhoto()
    {
        if (photoTaken) return;
        photoTaken = true;

        // Hide pixel scene
        pixelSceneRoot.SetActive(false);

        // Show photo frame
        photoFrameMask.gameObject.SetActive(true);

        // Get player position
        Vector3 playerPos = playerTransform.position;

        // Convert world position to UI offset
        float offsetX = -playerPos.x * pixelsPerUnit;
        float offsetY = -playerPos.y * pixelsPerUnit;

        // Move realistic image so the correct part is visible through the mask
        realisticImage.anchoredPosition = new Vector2(offsetX, offsetY);

        Debug.Log("Photo taken at player position: " + playerPos);
    }
}