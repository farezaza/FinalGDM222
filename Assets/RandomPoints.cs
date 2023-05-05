using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoints : MonoBehaviour
{
    public GameObject circlePrefab;
    public int minCircles;
    public int maxCircles;
    public float minRadius;
    public float maxRadius;
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

            // Set the radius of the circle to a random value between minRadius and maxRadius
            //CircleCollider2D collider = circle.GetComponent<CircleCollider2D>();
            //collider.radius = Random.Range(minRadius, maxRadius);

            // Set the position of the circle to a random position within the 10x10 area
            float x = Random.Range(-7f, 7f);
            float y = Random.Range(-3.5f, 3.5f);
            circle.transform.position = new Vector3(x, y, 0f);
        }
    }
}

