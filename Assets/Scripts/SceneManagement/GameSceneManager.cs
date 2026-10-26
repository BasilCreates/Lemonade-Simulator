using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    [SerializeField]
    private GameTimer gameTimer;    



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnEnable()
    {
        gameTimer.OnTimerEnd += HandleGameOver;
    }


    public void HandleGameOver() 
    {
        gameTimer.OnTimerEnd -= HandleGameOver;
        SceneManager.LoadScene("Lemonade Final Sim Menu UI");
    }

    public void RestartGameOnClick()
    {
        SceneManager.LoadScene("Lemonade Final Sim");
    }
}
