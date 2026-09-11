using UnityEngine;

public class Spaw2 : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabE1;
    public int xspw;
    public float timespw;
    private float time = 0;
    [SerializeField]
    private float distanceE;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timespw)
        {
            Spw();
            time = 0;

            xspw++;
            timespw = Mathf.Max(0.5f, timespw - 0.2f);
            
        }
    }
    private void Spw()
    {
        float ancho = distanceE * (xspw - 1);
        float posIY = transform.position.y - (ancho / 2f);
        for (int i = 0; i < xspw; i++)
        {
            float posY = posIY + (i * distanceE);
            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);

            Instantiate(prefabE1, pos, Quaternion.Euler(0, 0, 0));

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
