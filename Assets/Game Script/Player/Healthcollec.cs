using UnityEngine;

public class Healthcollec : MonoBehaviour
{
    [SerializeField] private float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerLife>().AddHealth(health);
            gameObject.SetActive(false);          
        }
    }
}
