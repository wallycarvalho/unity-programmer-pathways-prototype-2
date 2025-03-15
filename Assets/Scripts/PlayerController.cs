using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float xRange = 19.0f;
    private float zRange = 13.0f;
    public GameObject projectilePrefab;
    private float fireRate = 0.25f;
    private float nextFire = 0.0f;
    private bool hasNotifiedPlayer = false;

    private PlayerLives playerLives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLives = new PlayerLives();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // if value on X axis is beyond the minimum or maximum
        // we clamp to set a stopper value that makes sure the
        // player does not go beyond the set value
        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }


        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        // if the player presses space, we instantiate a new projectile
        // at the player's position and rotation so it moves forward
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    public void LoseLife()
    {
        if (playerLives.Lives <= 0 && hasNotifiedPlayer == false)
        {
            hasNotifiedPlayer = true;
            Debug.Log("Game Over! Player has no more lives.");
        }
        else if (playerLives.Lives > 0)
        {
            playerLives.LoseLife();
            Debug.Log("Player lost a life. Remaining lives: " + playerLives.Lives);
        }
    }

    public int GetLives()
    {
        return playerLives.Lives;
    }

    public void GainLife()
    {
        playerLives.GainLife();
        Debug.Log("Player gained a life. Total lives: " + playerLives.Lives);
    }
}
