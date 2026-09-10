using DG.Tweening;
using Unity.AI.MCP.Editor.Tools;
using UnityEngine;
public class Enemy2 : MonoBehaviour
{
    Rigidbody2D rbenemy;
    [SerializeField]
    private float speedenemy;
    [SerializeField]
    private float speedenemy2;
    [SerializeField]
    private int enemyhp = 5;
    [SerializeField]
    private float taryetY = -2f;
    [SerializeField]
    private float distsance;

    private bool posya = false;

    private void FixedUpdate()
    {
        if (!posya)
        {
            rbenemy.linearVelocity = new Vector2(0, -speedenemy);
            if (transform.position.y <= taryetY)
            {
                posya = true;
                rbenemy.linearVelocity = Vector2.zero;
            }
        }
        else
        {
                rbenemy.AddForce(Vector2.left * speedenemy2 * Time.deltaTime);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbenemy = GetComponent<Rigidbody2D>();
        taryetY = transform.position.y - distsance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {

            enemyhp--;

            GetComponent<SpriteRenderer>().material.DOColor(Color.red, 1).From();
            GetComponent<SpriteRenderer>().material.DOColor(Color.orange, 1);
            if (enemyhp <= 0)
            {
                manager.instance.addscore(20);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("killbox"))
        {
            Destroy(this.gameObject);

        }
    }
}
