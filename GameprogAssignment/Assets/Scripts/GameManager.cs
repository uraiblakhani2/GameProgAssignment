using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    private static GameManager instance;
    public static GameManager Instance { get { 
        if(instance == null)
                instance = FindObjectOfType<GameManager>();
        return instance;
        } }


    private int _score;
    public int score { get => _score; set { _score = value; if (onCoinChange != null)
                onCoinChange.Invoke();
        } }


    public delegate void OnCoinChange();
    public event OnCoinChange onCoinChange;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        if (instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
           

        DontDestroyOnLoad(gameObject);
    }

    public void ResetLevel()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }

}
