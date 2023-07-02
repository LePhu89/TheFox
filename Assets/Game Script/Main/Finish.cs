using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishAudiosource;
    //private bool levelComplete;
  
    private void Awake()
    {
        finishAudiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" /*&& !levelComplete*/)
        {
            finishAudiosource.Play();
            //levelComplete = true;
            //Invoke("CompleteLevel", 2f); //delay chuyen Level
            CompleteLevel();  //hoac dung Invoke  
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
