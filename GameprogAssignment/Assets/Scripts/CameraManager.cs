using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform  _target;
    [SerializeField] Transform  _cameraTransform;

    [SerializeField] float mouseTurnSpeed = 10f;
    [SerializeField] float sensetivitySpeed = 5.0f;
    [SerializeField] float forwaredMouseStep = 0.1f;

     Vector3 mousePosition;

    private void Start()
    {
        Cursor.visible = false;
        mousePosition = Camera.main.ScreenToViewportPoint( Input.mousePosition);
    }

    private void Update()
    {

        UpdateCamera();

        float distanceToCamera = Vector3.Distance(_cameraTransform.position, transform.position);
        Vector3 cameraDirection = (_cameraTransform.position - transform.position).normalized;


        
        var mDelta = Input.mouseScrollDelta;


        if (mDelta.y != 0)
        {
            distanceToCamera = distanceToCamera - mDelta.y * forwaredMouseStep ;
            distanceToCamera = Mathf.Clamp(distanceToCamera, 1f, 5f);
            _cameraTransform.position = transform.position + cameraDirection * distanceToCamera;
        }


        



        Vector3 mPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 delta = mPos - mousePosition;

        mousePosition = mPos;

        _target.transform.eulerAngles += new Vector3(0, delta.x, 0) * mouseTurnSpeed;
        transform.eulerAngles += new Vector3(-delta.y , 0 , 0) * mouseTurnSpeed;


      
        

    }

  

    void UpdateCamera()
    {
        transform.position = _target.position;
        _cameraTransform.transform.LookAt(_target.position + Vector3.up);
    }

  

}
