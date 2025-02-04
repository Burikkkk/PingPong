using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour
{
    public int sceneNumber;
    public string winnerName;
    public int scoreToReach;
    private int player1Score = 0;
    private int player2Score = 0;

    // Используем TextMeshProUGUI для UI-текста
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void PlayerGoal(int i)
    {
        if(i==1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else if(i==2)
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }
        CheckScore();
    }

    
    private void CheckScore()
    {
        
        if(player1Score==scoreToReach || player2Score == scoreToReach)
        {
            if (player1Score > player2Score)
                winnerName = "Bloom";
            else
                winnerName = "Valtor";
            sceneNumber = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(4);
        }

    }
}
