using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool wasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ѕерев≥р€Їмо в консол≥, чи взагал≥ хтось заходить в зону
        Debug.Log("’тось ув≥йшов в зону: " + other.name);

        if (other.CompareTag("Player") && !wasTriggered)
        {
            wasTriggered = true;
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddScore();
            }
            else
            {
                Debug.LogError("—крипт PlayerController не знайдено на об'Їкт≥ " + other.name);
            }
        }
    }
}