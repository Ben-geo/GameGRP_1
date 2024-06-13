using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;

    public float distanceToShoot = 5f;
    public float fireRate;
    private float timeToFire;

    public Transform firingPoint;

    public GameObject bulletPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeToFire = 0f;
    }

    void Update()
    {
        // Continuously search for the player
        target = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (target)
        {
            RotateTowardsTarget();
            DecideAction();
        }
    }

    private void DecideAction()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= distanceToShoot)
        {
            Shoot();
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    private void Shoot()
    {
        if (timeToFire <= 0f && bulletPrefab != null) // Check for null prefab
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
            rb.velocity = Vector2.zero; // Stop movement while shooting
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void MoveTowardsTarget()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        // Set velocity based on distance
        if (distance > distanceToShoot) // Consider using a buffer zone here (optional)
        {
            rb.velocity = (target.position - transform.position).normalized * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            target = null;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
