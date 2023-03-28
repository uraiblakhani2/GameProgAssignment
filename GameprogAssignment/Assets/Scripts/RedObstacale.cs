using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObstacale : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            if(GameManager.Instance != null)
                GameManager.Instance.ResetLevel();  
        }
    }
}
