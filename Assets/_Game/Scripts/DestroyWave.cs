using UnityEngine;

public class DestroyWave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform root = other.transform.root;

        if (root.CompareTag("Wave"))
        {
            Debug.Log("DESTROY WAVE: " + root.name);
            Destroy(root.gameObject);
        }
    }
}