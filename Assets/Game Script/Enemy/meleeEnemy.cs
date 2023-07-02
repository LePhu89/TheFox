using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackCooldow;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parametter")]
    [SerializeField] private float coliderDistance;
    private float cooldowTimer = Mathf.Infinity;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] LayerMask playerLayer;

    [Header("Player Layer")]
    private Animator animator;
    private PlayerLife playerHealth;

    private EnymyPatrol enemyPatrol;

    [Header("Sound")]
    [SerializeField] private AudioClip attackSound;

    private void Awake()
    {   
        animator= GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnymyPatrol>();
    }
    private void Update()
    {
        cooldowTimer += Time.deltaTime;
        //Attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldowTimer >= attackCooldow && playerHealth.currentHealth > 0)
            {
                //Attack
                cooldowTimer= 0;
                animator.SetTrigger("meleeattack");
                SoundManager.instance.PlaySound(attackSound);
            }
        }
        if(enemyPatrol != null)
        { 
            enemyPatrol.enabled = !PlayerInSight();
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * coliderDistance,
            new Vector3(boxCollider2D.bounds.size.x * range,boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if(hit.collider != null)
        {
            playerHealth = hit.collider.GetComponent<PlayerLife>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * coliderDistance,
            new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
