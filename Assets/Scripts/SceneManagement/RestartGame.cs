using UnityEngine;

public class RestartGame : MonoBehaviour
{
    
    public void RestartGameOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lemonade Final Sim");
    }
}
