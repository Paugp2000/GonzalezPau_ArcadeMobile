using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 clickedmousePosition;
    private Vector3 playerPosition;
    public float slideSpeed = 2f;
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        ManageControl();
    }

    public void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedmousePosition = Input.mousePosition;
            playerPosition = transform.position;

        }else if (Input.GetMouseButton(0))
        {
            float xScreenDiference =  Input.mousePosition.x - clickedmousePosition.x;
            xScreenDiference /= Screen.width;
            xScreenDiference *= slideSpeed;
            transform.position = clickedmousePosition
        }
    }
}
