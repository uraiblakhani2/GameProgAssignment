using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    [SerializeField] MeshRenderer   render;
    [SerializeField] SphereCollider sCollider;

    [SerializeField] Vector3 rotationAxis;
    [SerializeField] float rotationSpeed;
    [SerializeField] AudioClip clip;

    private void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

       

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController controller = other.GetComponent<PlayerController>();
          
            controller.AbilityDoubleJump = true;

            if (EffectManager.instance != null)
                EffectManager.instance.DoubleJumpEffect(transform.position);

            AudioSource.PlayClipAtPoint(clip, other.transform.position);

            render.enabled = false;
            sCollider.enabled = false;
            Invoke("Reset", 30f);
        }
    }

    private void Reset()
    {
        render.enabled = true;
        sCollider.enabled = true;
    }


}
