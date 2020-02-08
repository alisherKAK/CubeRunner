using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private Transform _root;

    [SerializeField]
    private Text _yourScoreText, _bestScoreText;

    [SerializeField]
    private Button _nextLevelButton, _quitButton;

    // Start is called before the first frame update
    private void Start()
    {
        _root.gameObject.SetActive(false);

        _nextLevelButton.onClick.AddListener(OnNextLevelClick);
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

    private void OnNextLevelClick()
    {
        SceneManager.LoadScene(2);
    }
    private void OnQuitClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        _nextLevelButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
    }
}
