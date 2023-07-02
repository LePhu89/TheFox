using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    [SerializeField] protected float damage;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.collider.GetComponent<PlayerLife>().TakeDamage(damage);
    //    }
    //}
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().TakeDamage(damage);
        }
    }
}
