using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;



    private void Start()
    {
        Cursor.visible = true;
        if(GameManager.Instance != null)
            scoreText.text = "Your Score : " + GameManager.Instance.score;
    }

    public void GoToMain()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.score = 0;
        SceneManager.LoadScene(0);
    }


}
