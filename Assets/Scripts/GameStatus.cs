using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void AddScore()
    {
        currentScore += pointsPerBlock;
        UpdateScoreText();
    }

    public void ResetSession()
    {
        Destroy(gameObject);
    }
}
