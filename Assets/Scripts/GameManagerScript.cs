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
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
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
