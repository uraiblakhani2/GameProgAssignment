using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] Vector3    rotationAxis;
    [SerializeField] float      rotationSpeed;
    [SerializeField] AnimationCurve curve;
    [SerializeField] AudioClip clip;


    private int scoreGain = 50;

    Vector3 intialPosition;

    private void Start()
    {
        intialPosition = transform.position;
    }


    private void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

        transform.position = intialPosition + curve.Evaluate((Time.time % 2 ) * 0.5f) * Vector3.up * 0.2f; 
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance != null)
                GameManager.Instance.score += scoreGain;
           
            if(EffectManager.instance != null)
                EffectManager.instance.CoinEffect(transform.position);
            AudioSource.PlayClipAtPoint(clip,other.transform.position);
            Destroy(gameObject);
        }
    }

}
