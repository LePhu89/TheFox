using UnityEngine;
using TMPro;

public class ItemCollection : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioClip colectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            SoundManager.instance.PlaySound(colectSound);
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
