using UnityEngine;

public class DestroyWave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform root = other.transform.root;

        if (!root.CompareTag("Wave"))
            return;

        WaveScore waveScore = root.GetComponent<WaveScore>();

        if (waveScore == null)
            return;

        if (waveScore.wasCounted)
            return;

        waveScore.wasCounted = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore();
        }

        Destroy(root.gameObject);
    }
}