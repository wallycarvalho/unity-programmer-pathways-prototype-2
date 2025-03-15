using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -15.0f;
    private float xBound = -23.0f;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindFirstObjectByType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // destroy object if it goes beyond the set value for top boundary
        // this is only being used by player projectiles
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);

        }
        // destroy object if it goes beyond the set value for bottom boundary
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            // if the object is a animal, we decrease the player's lives
            if (gameObject.CompareTag("Animal"))
            {
                playerController.LoseLife();
            }
        }
        else if (transform.position.x < xBound)
        {
            Destroy(gameObject);
            // if the object is a animal, we decrease the player's lives
            if (gameObject.CompareTag("Animal"))
            {
                playerController.LoseLife();
            }
        }
        else if (transform.position.x > -xBound)
        {
            Destroy(gameObject);
            // if the object is a animal, we decrease the player's lives
            if (gameObject.CompareTag("Animal"))
            {
                playerController.LoseLife();
            }
        }
    }
}
