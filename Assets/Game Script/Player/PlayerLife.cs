using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private UIManager ui;
    private BoxCollider2D boxCollider;

    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}

    [Header("Invisible")]
    [SerializeField]private float inviDuration; //thoi gian bat tu
    [SerializeField]private int numberFlicker;
    private SpriteRenderer sprite;
    private bool invisible;

    [Header("Sound")]
    [SerializeField] private AudioClip deadSound;
    [SerializeField] private AudioClip healthSound;

    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite= GetComponent<SpriteRenderer>();
        currentHealth = startingHealth;
        ui = FindObjectOfType<UIManager>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    public void TakeDamage(float _damage)
    {
        if (invisible) return;
        currentHealth= Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            //player hurt
            StartCoroutine(Invisible());
        }
        else
        {
            Die();
        }
    }
    public void AddHealth(float _value)
    {
        SoundManager.instance.PlaySound(healthSound);   
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Die()
    {
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }

        SoundManager.instance.PlaySound(deadSound);
        rb.bodyType = RigidbodyType2D.Static;
        boxCollider.enabled = false;
        anim.SetTrigger("Death");
        
    }
    private IEnumerator Invisible()
    {
        invisible= true;
        //Physics2D.IgnoreLayerCollision(9, 8, true);
        for (int i = 0; i < numberFlicker; i++)
        {
            sprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(inviDuration/ (numberFlicker * 2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(inviDuration/ (numberFlicker * 2));
        }
        //Physics2D.IgnoreLayerCollision(9, 8, false);
        invisible = false;

    }
    private void OverGame()
    {
        ui.GameOver();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
