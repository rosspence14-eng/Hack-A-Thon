using UnityEngine;

public class AlarmTileTrigger2D : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Debug.Log("Alarm triggered at tile: " + gameObject.name);
            ChaosManager.Instance.AddChaos();
            GetComponent<SpriteRenderer>().color = Color.gray; // Optional visual feedback
        }
    }
}