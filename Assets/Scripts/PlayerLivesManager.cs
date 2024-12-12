using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLivesManager : MonoBehaviour
{
    public static PlayerLivesManager instance; // Singleton instance
    public Text livesText; // UI Text to display lives
    public Text loseText; // UI Text to display "You Lose!" message
    private int lives = 3; // Initial lives count
    public GameObject player; // Reference to the player GameObject

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
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
        UpdateLivesUI(); // Update UI at the start
        loseText.gameObject.SetActive(false); // Hide the "You Lose!" text initially
    }

    // Method to reduce lives
    public void ReduceLife()
    {
        lives--; // Decrease lives
        UpdateLivesUI(); // Update the UI

        Debug.Log("Lives remaining: " + lives);

        // Check if lives reach zero
        if (lives <= 0)
        {
            TriggerGameOver(); // Call the game over logic
        }
    }

    // Updates the lives UI
    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    // Trigger the game over logic when the player has no more lives
    private void TriggerGameOver()
    {
        Debug.Log("Game Over! Player has no more lives.");

        // Display "You Lose!" message
        if (loseText != null)
        {
            Destroy(player); // Destroy the player GameObject
            Debug.Log("Player has been destroyed!");
            loseText.gameObject.SetActive(true); // Show the "You Lose!" text
        }

        // Restart the game after 2 seconds
        Invoke("RestartGame", 2f);
    }


    // Restart the game by reloading the current scene
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
