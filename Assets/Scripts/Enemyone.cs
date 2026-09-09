using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rbenemy;
    [SerializeField]
    private float speedenemy;

    
    void Start()
    {
    }
    private void FixedUpdate()
    {
        rbenemy = GetComponent<Rigidbody2D>();
        rbenemy.AddForce(Vector2.left * speedenemy * Time.deltaTime);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            manager.instance.addscore(10);
            Destroy(this.gameObject);
        }
    }
}

