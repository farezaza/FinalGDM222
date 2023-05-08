using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startTime;
    public bool timeOut = false;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;

        // Add the KMeansCalculator component to the CountdownTimer instance
        //KMeansCalculator kMeansCalculator = gameObject.AddComponent<KMeansCalculator>();
        //kMeansCalculator.enabled = false;

        StartCoroutine(StartKMeansAfterCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOut == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }

        if (currentTime <= 3.999)
        {
            countdownText.color = Color.red;
            countdownText.text = currentTime.ToString("0.0");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            timeOut = true;
        }
    }

    IEnumerator StartKMeansAfterCountdown()
    {
        while (!timeOut)
        {
            yield return null;
        }

        // Wait for the next frame
        yield return new WaitForEndOfFrame();

    }

}
