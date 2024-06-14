using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleBox : MonoBehaviour
{
    // Jump related variables
    public float jumpHeight = 2f;
    public float jumpDuration = 0.5f;
    public float waitTime = 2f;

    // Wiggle related variables
    public float wiggleAmount = 10f;
    public float wiggleSpeed = 20f;
    private float timePassed = 0f;

    // When you click the button
    public bool clickBtn = false;

    // Store original position
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position; // Store the original position
        StartCoroutine(JumpRoutine()); // Start the jumping routine
    }

    void Update()
    {
        if (clickBtn)
            Wiggle();
    }

    // Wiggle for 3 second
    void Wiggle()
    {
        if (timePassed < 3)
        {
            // Generate random angles for all three axes using Perlin noise for smoother transition
            float angleX = Mathf.PerlinNoise(timePassed * wiggleSpeed, 0) * wiggleAmount * 2 - wiggleAmount;
            float angleY = Mathf.PerlinNoise(0, timePassed * wiggleSpeed) * wiggleAmount * 2 - wiggleAmount;
            float angleZ = Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount; // Original z-axis wiggle

            transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
            timePassed += Time.deltaTime;
        }
    }

    // Box jumping coroutine
    IEnumerator JumpRoutine()
    {
        while (!clickBtn) // Infinite loop to keep jumping
        {
            // Animate jump up and down using a sine wave
            float timer = 0f;
            while (timer < jumpDuration)
            {
                float fraction = timer / jumpDuration;
                float verticalPosition = Mathf.Sin(fraction * Mathf.PI) * jumpHeight; // Sine wave for smooth jump
                transform.position = originalPosition + new Vector3(0, verticalPosition, 0);
                timer += Time.deltaTime;
                yield return null;
            }
            transform.position = originalPosition; // Reset position after jump

            yield return new WaitForSeconds(waitTime); // Wait before the next jump
        }
    }

    // Click select subject button
    public void OnClickSelectSubject()
    {
        clickBtn = true;
    }
}
