using DG.Tweening;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    Rigidbody2D rbenemy;
    [SerializeField]
    private float speedenemy;
  
    [SerializeField]
    private int enemyhp = 5;
    private void FixedUpdate()
    {
        rbenemy = GetComponent<Rigidbody2D>();
        rbenemy.AddForce(Vector2.left * speedenemy * Time.deltaTime);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            GetComponent<SpriteRenderer>().material.DOColor(Color.gray, 1);
            if (enemyhp <= 0)
            {
                manager.instance.addscore(35);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("killbox"))
        {
            Destroy(this.gameObject);

        }
    }
}
