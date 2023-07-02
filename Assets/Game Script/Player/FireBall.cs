using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private float lifeTime;

    private Animator animator;
    private BoxCollider2D boxCollider2D;

    

    private void Awake()
    {
        animator= GetComponent<Animator>();
        boxCollider2D= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float moveSpeed = speed * Time.deltaTime * direction;
        transform.Translate(moveSpeed,0,0);
        lifeTime += Time.deltaTime;
        if(lifeTime > 5) gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit= true;
        boxCollider2D.enabled = false;
        animator.SetTrigger("explode");
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamageEnemy(1);
        }
    }
    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit= false;
        boxCollider2D.enabled = true;
        
        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void DeActive()
    {
        gameObject.SetActive(false);
    }
}
