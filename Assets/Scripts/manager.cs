using UnityEngine;
using TMPro;

public class manager : MonoBehaviour
{
   public static manager instance;
    private int score;
    [SerializeField]
    private TMP_Text Scoretext;
    [SerializeField]
    private GameObject gameover;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loose()
    {
        gameover.SetActive(true);
    }
    public void addscore(int scores)
    {
        score += scores;
        Scoretext.text = "Score:" + score.ToString();
    }
}
