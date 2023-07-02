using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] traps;

    private void Awake()
    {
        foreach (var item in traps)
        {
            item.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            foreach (var item in traps)
            {
                item.SetActive(true);
            }

        }
    }
}
