using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int posX = 20;
    private int posZ = 20;
    private float initialTimeForInvokingAnimal = 1.0f;
    private float repeatTimeStart = 1.5f;
    private float repeatTimeEnd = 1.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("InstantiateRandomAnimal", initialTimeForInvokingAnimal, Random.Range(repeatTimeStart, repeatTimeEnd));
        InvokeRepeating("InstantiateRandomLeftAnimal", initialTimeForInvokingAnimal, Random.Range(repeatTimeStart, repeatTimeEnd));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateRandomAnimal()
    {
        // Instantiate the animal at a random position
        int animalReference = Random.Range(0, animalPrefabs.Length);
        Vector3 topDownCoordinates = new Vector3(Random.Range(-posX, posX), 0, posZ);
        Instantiate(animalPrefabs[animalReference], topDownCoordinates, animalPrefabs[animalReference].transform.rotation);


        int randomRangeForRight = Random.Range(-posZ + 10, posZ - 11);

        Vector3 rightLeftCoordinates = new Vector3(posX, 0, randomRangeForRight);
        Quaternion animalLeftRotation = Quaternion.Euler(0, 90, 0) * animalPrefabs[animalReference].transform.rotation;
        Instantiate(animalPrefabs[animalReference], rightLeftCoordinates, animalLeftRotation);
    }

    void InstantiateRandomLeftAnimal()
    {
        int animalReference = Random.Range(0, animalPrefabs.Length);

        int randomRangeForLeft = Random.Range(-posZ + 10, posZ - 11);
        Vector3 leftRightCoordinates = new Vector3(-posX, 0, randomRangeForLeft);
        Quaternion animalRightRotation = Quaternion.Euler(0, -90, 0) * animalPrefabs[animalReference].transform.rotation;
        Instantiate(animalPrefabs[animalReference], leftRightCoordinates, animalRightRotation);
    }
}
