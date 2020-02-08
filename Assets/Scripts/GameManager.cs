using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameOverPanel _gameOverPanel;

    [SerializeField]
    private WinPanel _winPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameOver(int score)
    {
        _gameOverPanel.SetPanelActive(true);
        _gameOverPanel.SetScoreText(score);
    }
    public void WinGame(int score)
    {
        _winPanel.SetPanelActive(true);
        _winPanel.SetScoreText(score);
    }
}
