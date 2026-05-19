using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Sun")]
    public Light directionalLight;
    public float sunRotationSpeed = 5f;

    [Header("Skybox Blend")]
    public Material blendSkybox;
    public float transitionSpeed = 0.2f;

    private float blendValue = 0f;
    private bool goingToNight = true;

    void Update()
    {
        RotateSun();
        AnimateSkybox();
    }

    void RotateSun()
    {
        if (directionalLight != null)
        {
            directionalLight.transform.Rotate(
                Vector3.right *
                sunRotationSpeed *
                Time.deltaTime
            );
        }
    }

    void AnimateSkybox()
    {
        if (blendSkybox == null)
            return;

        if (goingToNight)
        {
            blendValue += transitionSpeed * Time.deltaTime;

            if (blendValue >= 1f)
            {
                blendValue = 1f;
                goingToNight = false;
            }
        }
        else
        {
            blendValue -= transitionSpeed * Time.deltaTime;

            if (blendValue <= 0f)
            {
                blendValue = 0f;
                goingToNight = true;
            }
        }

        blendSkybox.SetFloat("_CubemapTransition", blendValue);
    }
}