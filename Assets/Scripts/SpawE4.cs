using UnityEngine;

public class SpawE4 : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabE1;
    public int xspw;
    public float timespw;
    private float time = 0;
    [SerializeField]
    private float distanceE;
    [SerializeField]
    private float minY = -4.46f;
    [SerializeField]
    private float maxY = 8.35f;
    


    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timespw)
        {
            Spw();
            time = 0;

           
            timespw = Mathf.Max(0.5f, timespw - 0.2f);
            

        }
    }
    private void Spw()
    {
        
        for (int i = 0; i < xspw; i++)
        {
            float posY = Random.Range(minY, maxY);
            Vector3 pos = new Vector3(transform.position.x, posY, transform.position.z);

            Instantiate(prefabE1, pos, Quaternion.Euler(0, 0, 0));

        }
    }
}
