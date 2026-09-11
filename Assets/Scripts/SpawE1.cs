using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class SpawE1 : MonoBehaviour
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

            xspw+= 3;
            timespw += 5;
        }
    }
    private void Spw()
    {
        float ancho = distanceE * (xspw - 1);
        float posIX = transform.position.x - (ancho / 2f);
        for ( int i = 0; i < xspw; i++)
        {
            float posX = posIX + (i * distanceE);
            Vector3 pos = new Vector3(posX, transform.position.y, transform.position.z);

            Instantiate(prefabE1, pos, Quaternion.Euler(0,0,90));
            
        }
    }
}
