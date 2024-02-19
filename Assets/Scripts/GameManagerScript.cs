using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;

    [SerializeField] private GameObject gameStartCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void StartFlapping()
    {
        gameStartCanvas.SetActive(false);
    }
}
