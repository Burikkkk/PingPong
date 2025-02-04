using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public TMP_Text winnerText;
    public GameObject panel;
    public Image background;
    public Sprite backBloom;
    public Sprite backValtor;
    public AudioSource sound;
    public AudioClip soundBloom;
    public AudioClip soundValtor;

    public void MoveToScene(int SceneID)
    {
        var scoreManager = FindObjectOfType<ScoreManager>();
        if(scoreManager!=null)
            Destroy(scoreManager.gameObject);
        SceneManager.LoadScene(SceneID); // Загрузка сцены по ID
    }

    
    private void Start()
    {
        if (winnerText != null)
        {

            var scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager == null)
                return;
            winnerText.text = scoreManager.winnerName + " won!";

            if (scoreManager.winnerName == "Bloom")
            {
                background.sprite = backBloom;
                sound.clip = soundBloom;
            }

            else
            { 
                background.sprite = backValtor;
                sound.clip = soundValtor;
            }
            sound.Play();

        }
    }

    public void Quit()
    {
        Application.Quit(); // Закрытие приложения
    }

    public void Panel()
    {
        panel.SetActive(true);
    }

    public void Replay()
    {
        var scoreManager=FindObjectOfType<ScoreManager>();
        int scene = scoreManager.sceneNumber;
        Destroy(scoreManager.gameObject);
        MoveToScene(scene);

    }
}
