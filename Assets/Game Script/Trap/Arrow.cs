using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;

    [SerializeField] private AudioClip arrowAudio;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(cooldownTimer > attackCooldown)
        {
            Attack();
        }

    }
    private void Attack()
    {
        SoundManager.instance.PlaySound(arrowAudio);
        cooldownTimer = 0;

        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActiveProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy) 
                return i;           
        }
        return 0;
    }
}
