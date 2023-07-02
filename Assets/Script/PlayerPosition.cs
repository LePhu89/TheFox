using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    List<GameObject> minions ;
    public GameObject minionPrefab;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        minions= new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        CheckMinionDeath();
        
    }
    void CheckMinionDeath()
    {
        GameObject minion;
        for (int i = 0; i < minions.Count ; i++)
        {
            minion = minions[i];
            if (minion == null) minions.RemoveAt(i);
        }
    }
    void Spawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer < spawnDelay) return;
        spawnTimer = 0f;

        if(minions.Count >= 7) { return; }
        int i = minions.Count +1 ;
        GameObject minion = Instantiate(minionPrefab) ;
        minion.name = "Boom #" + i;
        minion.SetActive(true);
        
        this.minions.Add(minion);
        minion.transform.position = transform.position;
    }
    
}
