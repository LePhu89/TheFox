using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : DamageTrap
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;
    private bool hit;

    private BoxCollider2D collider2d;
    private Animator anim;

    private void Awake()
    {
        collider2d= GetComponent<BoxCollider2D>();
        anim= GetComponent<Animator>();
    }
    private void Update()
    {
        if (hit) return;
        transform.Translate(speed * Time.deltaTime, 0, 0);

        lifeTime += Time.deltaTime;
        if(lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void ActiveProjectile()
    {
        hit = false;
        lifeTime = 0;       
        gameObject.SetActive(true);
        collider2d.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);
        collider2d.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode"); 
        else
            gameObject.SetActive(false); 
        
    }
    private void DeActive()
    {
        gameObject.SetActive(false);
    }
}
