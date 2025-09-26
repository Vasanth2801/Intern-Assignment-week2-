using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;      // Singleton instance

    private void Awake()
    {
        if (instance == null)               // If no instance exists, set this as the instance
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);            // If an instance already exists, destroy this object
        }
    }


    // Call this method to start the camera shake
    public IEnumerator Shake(float duration, float magnitude)
   { 
      Vector3 originalPos = transform.localPosition;             // Store the original position of the camera
        float elapsed = 0.0f;                                 // Time elapsed since the shake started
        while (elapsed < duration)                              // Shake for the specified duration
        {
         float x = Random.Range(-1f, 1f) * magnitude;            // Random x offset
         float y = Random.Range(-1f, 1f) * magnitude;             // Random y  offset
         transform.localPosition = new Vector3(x, y, originalPos.z);   // Apply the shake offset
            elapsed += Time.deltaTime;                              // Increment elapsed time
            yield return null;                                   // Wait for the next frame
        } 
      transform.localPosition = originalPos;                   // Reset to original position after shaking
    }
}
