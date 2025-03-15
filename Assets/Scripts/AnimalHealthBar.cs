using UnityEngine;
using UnityEngine.UI;

public class AnimalHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public int amountToBeHealed = 3;
    private int currentAmount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.fillRect.gameObject.SetActive(true);
        healthBar.minValue = 0;
        healthBar.maxValue = amountToBeHealed;
        healthBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHealth()
    {
        currentAmount++;
        healthBar.value = currentAmount;
        if (currentAmount >= amountToBeHealed)
        {
            healthBar.value = 0;
            currentAmount = 0;
            Destroy(gameObject);
            healthBar.fillRect.gameObject.SetActive(false);
        }
    }
}
