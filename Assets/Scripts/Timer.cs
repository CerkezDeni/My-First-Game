using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime = 0f; // Timer start time in seconds
    private float currentTime;
    private bool isRunning = true;
    private TextMeshProUGUI timerText;
    private Player player; // Reference to the Player script

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>(); // Find the Player instance
        ResetTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;

            if (player.CoinCount <= 0)
            {
                isRunning = false;
            }

            UpdateTimerText();
        }
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        UpdateTimerText()  ;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = formattedTime;
    }
}