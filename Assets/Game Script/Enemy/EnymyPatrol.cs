using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnymyPatrol : MonoBehaviour
{
    [Header("Patrol point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTime;

    private void Awake()
    {
        initScale= enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x) 
                MoveInDirection(-1);
            
            else 
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();     
        }
        
    }
    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTime += Time.deltaTime;
        if(idleTime > idleDuration)
        {
            movingLeft = !movingLeft;
        }     
    }

    private void MoveInDirection(int _direction)
    {
        idleTime = 0;
        anim.SetBool("moving", true);
        //make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,initScale.y,initScale.z);
        //move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
