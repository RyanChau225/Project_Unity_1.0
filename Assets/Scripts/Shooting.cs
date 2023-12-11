using System.Collections;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 13;
    public GameObject muzzleFlashPrefab;

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = cursorPosition - firePointPosition;
        direction.Normalize(); // Normalize the direction

        float lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(direction, lookAngle);

        }
    }

    void Shoot(Vector2 direction, float angle)
    {
        GameObject bulletClone = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, angle));
        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        // Disable the bullet's collider immediately
        Collider2D bulletCollider = bulletClone.GetComponent<Collider2D>();
        if (bulletCollider != null)
        {
            bulletCollider.enabled = false;
        }

        // Enable the collider after a short delay
        StartCoroutine(EnableColliderAfterDelay(bulletCollider, 0.1f));

        // Ignore collision between bullet and player
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (bulletCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, playerCollider);
        }

        if (muzzleFlashPrefab != null)
        {
            Debug.Log("Instantiating muzzle flash");
            var muzzleFlash = Instantiate(muzzleFlashPrefab, new Vector3(firePoint.position.x, firePoint.position.y, -1), firePoint.rotation);

            Destroy(muzzleFlash, 0.5f); // Adjust time as needed
        }
        else
        {
            Debug.Log("Muzzle flash prefab not assigned");
        }

    }

    IEnumerator EnableColliderAfterDelay(Collider2D collider, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (collider != null)
        {
            collider.enabled = true;
        }
    }
}
