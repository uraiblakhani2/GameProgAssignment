using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;


    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.onCoinChange += UpdateScore;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.onCoinChange -= UpdateScore;
    }

    private void Start()
    {
        UpdateScore();
    }


   


    void UpdateScore()
    {
        if(GameManager.Instance != null)
            scoreText.text = "Score : " + GameManager.Instance.score;
    }


}
