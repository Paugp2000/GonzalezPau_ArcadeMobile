using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 clickedmousePosition;
    private Vector3 clickedplayerPosition;
    public float slideSpeed = 7f;
    public float moveSpeed = 2f;
    private Animator [] animator;
    private int numPlayers;
    private void Start()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            animator[i] = GetComponentsInChildren<Animator>()[i];
        }
    }
    private void Update()
    {
        
        MoveForward();
        ManageControl();

    }
    public void MoveForward()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        for (int i = 0; i < numPlayers; i++)
        {
            animator[i].SetBool("IsRunning", true);
        }
    }
    public void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedmousePosition = Input.mousePosition;
            clickedplayerPosition = transform.position;
            

        }else if (Input.GetMouseButton(0))
        {
            float xScreenDiference =  Input.mousePosition.x - clickedmousePosition.x;
            xScreenDiference /= Screen.width;
            xScreenDiference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedplayerPosition.x + xScreenDiference;
            transform.position =  position;  
        }
    }
}
