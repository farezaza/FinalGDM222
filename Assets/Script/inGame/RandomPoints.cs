using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoints : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject centroidPrefab;

    // Min and max circles point to be generated
    public int minCircles;
    public int maxCircles;
    public int centroidAmount;

    public float minDistance;

    private void Start()
    {
        // Generate a random number of circles between minCircles and maxCircles
        int numCircles = Random.Range(minCircles, maxCircles + 1);

        // Spawn the circles
        for (int i = 0; i < numCircles; i++)
        {
            // Create a new circle GameObject from the prefab
            GameObject circle = Instantiate(circlePrefab, transform);

            // Set the position of the circle to a random position within the specified range
            float x = Random.Range(-7f, 7f);
            float y = Random.Range(-3.5f, 3.5f);
            circle.transform.position = new Vector3(x, y, 0f);
        }

        // Spawn the centroid squares
        for (int a = 0; a < centroidAmount; a++)
        {
            // Create a new centroid square GameObject from the prefab
            GameObject centroid = Instantiate(centroidPrefab, transform);

            // Set the position of the centroid square to a random position within the specified range
            float x = Random.Range(-7f, 7f);
            float y = Random.Range(-3.5f, 3.5f);
            centroid.transform.position = new Vector3(x, y, 0f);
        }

        // Start K-means calculation
        KMeansCalculator kMeansCalculator = GetComponent<KMeansCalculator>();
        kMeansCalculator.k = centroidAmount;
        kMeansCalculator.iterations = 5;
        kMeansCalculator.enabled = true;
    }
}
