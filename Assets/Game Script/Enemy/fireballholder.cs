using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballholder : MonoBehaviour
{
    [SerializeField] Transform enemy;

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
