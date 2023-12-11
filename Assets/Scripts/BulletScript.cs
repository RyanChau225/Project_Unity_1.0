using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rotationSpeed = -1000; // Rotation speed in degrees per second
    public float maxTravelDistance = 10f;
    private Vector2 startPosition;
    public float lifespan = 5f;

    void Start()
    {
        startPosition = transform.position;
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // Rotate the bullet around its z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Check if the bullet has exceeded the max travel distance
        if (Vector2.Distance(startPosition, transform.position) > maxTravelDistance)
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
        }
        else if (collision.gameObject.CompareTag("Prop")) // Check for collision with a prop
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
