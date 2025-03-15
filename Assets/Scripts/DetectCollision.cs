using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    PlayerController playerController;

    AnimalHealthBar animalHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindFirstObjectByType<PlayerController>();
        animalHealthBar = GameObject.FindFirstObjectByType<AnimalHealthBar>();

        if (animalHealthBar == null)
        {
            Debug.LogError("AnimalHealthBar not found in the scene.");
        }

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected between " + gameObject.name + " and " + other.gameObject.name);
        if (gameObject.CompareTag("Player") && playerController.GetLives() == 0)
        {
            Debug.Log("Player has no more lives.");
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && playerController.GetLives() == 0)
        {
            Debug.Log("Player has no more lives.");
            Destroy(other.gameObject);
        }
        else if (gameObject.CompareTag("Animal") && other.gameObject.CompareTag("Projectile"))
        {
            // start with destroying projectile
            Destroy(other.gameObject);
            playerController.GainLife();
            Debug.Log("Player gained a life.");
            // Check if animalHealthBar is not null before calling AddHealth
            if (animalHealthBar != null)
            {
                animalHealthBar.AddHealth();
            }
            else
            {
                Debug.LogError("AnimalHealthBar is null.");
            }
        }
        else if (other.gameObject.CompareTag("Animal") && gameObject.CompareTag("Projectile"))
        {
            // start with destroying projectile
            Destroy(gameObject);

            playerController.GainLife();
            Debug.Log("Player gained a life.");
            // Check if animalHealthBar is not null before calling AddHealth
            if (animalHealthBar != null)
            {
                animalHealthBar.AddHealth();
            }
            else
            {
                Debug.LogError("AnimalHealthBar is null.");
            }
        }
    }
}
