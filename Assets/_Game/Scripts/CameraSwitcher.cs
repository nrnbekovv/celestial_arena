using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera topDownCamera;

    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        topDownCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            mainCamera.gameObject.SetActive(false);
            topDownCamera.gameObject.SetActive(true);
        }
        else
        {
            mainCamera.gameObject.SetActive(true);
            topDownCamera.gameObject.SetActive(false);
        }
    }
}