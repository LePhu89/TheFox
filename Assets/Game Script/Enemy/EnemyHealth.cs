using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Behaviour[] components;

    [Header("Sound")]
    [SerializeField] private AudioClip deadAudio;

    [SerializeField] private GameObject finish; 
   
    private void Awake()
    {
        anim= GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        finish.SetActive(false);
    }

    public void TakeDamageEnemy(float _damageE)
    {
        enemyHealth = enemyHealth - _damageE;
        if(enemyHealth > 0)
        {
            //Enemy hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            //Enemy Die
            foreach (Behaviour component in components)
            {
                component.enabled = false;
            }

            boxCollider2D.enabled = false;
            anim.SetTrigger("die");                     
            SoundManager.instance.PlaySound(deadAudio);
            finish.SetActive(true);
        }
    }
    private void DeActive()
    {
        gameObject.SetActive(false);            
    }

}
