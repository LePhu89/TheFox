using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainmenu : MonoBehaviour
{
    [SerializeField] private GameObject aboutPanal;
 
    private void Awake()
    {
        aboutPanal.SetActive(false);
    }
    public void AboutPannal()
    {
        aboutPanal.SetActive(true);
    }
    public void Startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        aboutPanal.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
