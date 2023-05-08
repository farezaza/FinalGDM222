using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMeansCalculator : MonoBehaviour
{
    public GameObject squarePrefab;
    public int k;
    public int iterations = 10;
    public CountdownTimer countdownTimer;

    private List<GameObject> squares = new List<GameObject>();
    private List<Vector2> centroids = new List<Vector2>();

    private void Start()
    {
        Time.timeScale = 1f;

        // Find centroids
        FindCentroids();

        // Find points (excluding centroids)
        FindPoints();

        // Spawn squares at random positions if no points found
        if (squares.Count == 0)
        {
            SpawnRandomSquares();
        }
    }

    private void FindCentroids()
    {
        GameObject[] centroidObjects = GameObject.FindGameObjectsWithTag("Centroid");
        foreach (GameObject centroidObject in centroidObjects)
        {
            centroids.Add(centroidObject.transform.position);
        }
    }

    private void FindPoints()
    {
        GameObject[] pointObjects = GameObject.FindGameObjectsWithTag("Point");
        foreach (GameObject pointObject in pointObjects)
        {
            if (!pointObject.CompareTag("Centroid"))
            {
                squares.Add(pointObject);
            }
        }
    }

    private void SpawnRandomSquares()
    {
        for (int i = 0; i < k; i++)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            GameObject square = Instantiate(squarePrefab, new Vector3(x, y, 0f), Quaternion.identity);
            squares.Add(square);
        }
    }

    public void UpdateCentroids()
    {
        centroids.Clear();
        FindCentroids();
    }

    private void Update()
    {
        if (countdownTimer.timeOut)
        {
            //Update player centroids
            UpdateCentroids();

            // Perform k-means clustering
            for (int i = 0; i < iterations; i++)
            {
                // Assign each square to the nearest centroid
                foreach (GameObject square in squares)
                {
                    int nearestCentroidIndex = GetNearestCentroidIndex(square.transform.position);
                    square.GetComponent<SpriteRenderer>().color = GetColor(nearestCentroidIndex);
                }
            }
        }
    }

    private int GetNearestCentroidIndex(Vector2 position)
    {
        float minDistance = Mathf.Infinity;
        int nearestCentroidIndex = -1;
        for (int i = 0; i < centroids.Count; i++)
        {
            float distance = Vector2.Distance(position, centroids[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestCentroidIndex = i;
            }
        }
        return nearestCentroidIndex;
    }

    private Color GetColor(int index)
    {
        switch (index)
        {
            // Player color
            case 1:
                return Color.blue;

            default:
                return Color.gray;
        }
    }
}
