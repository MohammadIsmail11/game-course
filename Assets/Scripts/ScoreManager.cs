using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    public Text scoreText; // UI Text to display the score
    public Text winText; // UI Text to display the "You Win!" message
    private int score = 0; // Initial score

    private void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI(); // Update the UI at the start
        winText.gameObject.SetActive(false); // Hide the "You Win!" text initially
    }

    // Method to add to the score
    public void AddScore(int amount)
    {
        score += amount; // Increase the score
        UpdateScoreUI(); // Update the UI

        Debug.Log("Score: " + score);

        // Check for win condition
        if (score >= 500)
        {
            WinGame();
        }
    }

    // Updates the score UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Handles winning the game
    private void WinGame()
    {
        Debug.Log("You Win!");
        winText.gameObject.SetActive(true); // Display the "You Win!" message
        Invoke("RestartGame", 2f); // Restart the game after a 2-second delay
    }

    // Restarts the game
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
