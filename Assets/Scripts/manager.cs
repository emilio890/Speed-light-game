using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class manager : MonoBehaviour
{
    [SerializeField]
    private InputAction esc;
    public static manager instance;
    private int score;
    private float time;
    
    [SerializeField]
    private TMP_Text Scoretext;
    [SerializeField]
    private TMP_Text hightscore;
    [SerializeField]
    private TMP_Text hightime;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private GameObject pnaleinicio;
    [SerializeField]
    private GameObject pauseoanel;
    public static bool iniciojuego = false;
    private bool pausaon = false;

    private void OnEnable()
    {
        esc.Enable();
    }
    private void OnDisable()
    {
        esc.Disable();
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       

        int recordGuardado = PlayerPrefs.GetInt("HighScore", 0);
        float timesurvive = PlayerPrefs.GetFloat("HighTime", 0f);
        if (hightscore != null)
        {
            hightscore.text = "High Score: " + recordGuardado;
        }
        if (hightime != null)
        {
            hightime.text = "High Time: " + timesurvive;
        }
        if (iniciojuego == true)
        {
            pnaleinicio.SetActive(false);
            playbutton();
            iniciojuego = false;
        }
        else
        {
            pnaleinicio.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (esc.triggered)
        {
            pausa();
            pausaon = true;
        }
    }
    public void loose()
    {
        gameover.SetActive(true);

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            
            PlayerPrefs.SetInt("HighScore", score);

            if (hightscore != null)
            {
                hightscore.text = "High Score: " + score;
            }
        }

        if (PlayerPrefs.GetFloat("HighTime") < time)
        {
            
            PlayerPrefs.SetFloat("HighTime", time);

            if (hightscore != null)
            {
                hightscore.text = "High Time: " + time;
            }
        }
    }
    public void addscore(int scores)
    {
        score += scores;
        Scoretext.text = "Score:" + score.ToString();
    }

    
    public void playbutton()
    {
        pnaleinicio.SetActive(false);
        pauseoanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void retrybottom()
    {
        
        iniciojuego = true;
        SceneManager.LoadScene(0);
    }
    public void reloadmenubutton()
    {
        pauseoanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void quitbutton()
    {
        Application.Quit();
    }
    public void pausa()
    {
        if (pausaon == false)
        {

        }
        else
        {
            Time.timeScale = 0f;
            pauseoanel.SetActive(true);
        }
    }
    public void despausa()
    {
        pausaon = false;
        Time.timeScale = 1f;
        pauseoanel.SetActive(false);
    }
}
