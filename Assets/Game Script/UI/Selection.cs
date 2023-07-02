using UnityEngine;
using UnityEngine.UI;


public class Selection : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform recttranform;
    private int currentPosition;

    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip enterSound;

    private void Awake()
    {
        recttranform= GetComponent<RectTransform>(); 
        currentPosition=0;
        ChangePosition(0);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            ChangePosition(-1);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PressEnter();
        }
    }
    
    private void ChangePosition(int _change)
    {
        currentPosition += _change;
        if(_change != 0)
        {
            SoundManager.instance.PlaySound(changeSound);
        }
        if(currentPosition < 0 )
        {
            currentPosition = options.Length - 1;
        }
        else if(currentPosition > options.Length - 1)
        {
            currentPosition= 0;
        }
        //vi tri con cao
        recttranform.position = new Vector3(recttranform.position.x, options[currentPosition].position.y, 0);
    }
    private void PressEnter()
    {
        SoundManager.instance.PlaySound(enterSound);       
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
