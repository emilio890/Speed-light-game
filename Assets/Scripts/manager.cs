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
    [SerializeField]
    private TMP_Text Scoretext;
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
        if (esc.triggered)
        {
            pausa();
            pausaon = true;
        }
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

    
    public void playbutton()
    {
        pnaleinicio.SetActive(false);
        Time.timeScale = 1f;
    }
    public void retrybottom()
    {
        iniciojuego = true;
        SceneManager.LoadScene(0);
    }
    public void reloadmenubutton()
    {
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
