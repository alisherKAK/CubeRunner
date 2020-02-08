using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Transform _root;

    [SerializeField]
    private Text _yourScoreText, _bestScoreText;

    [SerializeField]
    private Button _restartButton, _quitButton;

    [SerializeField]
    private int _level;

    // Start is called before the first frame update
    private void Start()
    {
        _root.gameObject.SetActive(false);

        _restartButton.onClick.AddListener(OnRestartClick);
        _quitButton.onClick.AddListener(OnQuitClick);
    }

    public void SetPanelActive(bool state)
    {
        _root.gameObject.SetActive(state);
    }

    public void SetScoreText(int score)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore = score;
        }

        _yourScoreText.text = "Score: " + score.ToString();
        _bestScoreText.text = "Best score: " + bestScore;
    }

    private void OnRestartClick()
    {
        SceneManager.LoadScene(_level);
    }
    private void OnQuitClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
    }
}
