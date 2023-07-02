using UnityEngine;
using UnityEngine.UI;

public class Heathbar : MonoBehaviour
{
    [SerializeField] private PlayerLife playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth/10;
    }
}
