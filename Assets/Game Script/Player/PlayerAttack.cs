using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    PlayerMovement playerMovement;
    [SerializeField] private float cooldowAttack;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float cooldowTime; /*= Mathf.Infinity;*/

    [Header ("Sound")]
    [SerializeField] private AudioClip fireBallSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement= GetComponent<PlayerMovement>();

    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && playerMovement.CanAttack() && cooldowTime > cooldowAttack)
        {
            Attack();           
        }
        cooldowTime += Time.deltaTime;
    }
    private void Attack()
    {
        SoundManager.instance.PlaySound(fireBallSound);
        anim.SetTrigger("attack");
        cooldowTime = 0;

        fireballs[FindFireBall()].transform.position = firePoint.position;
        fireballs[FindFireBall()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireBall()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy) return i;
        }
        return 0;
    }

}
