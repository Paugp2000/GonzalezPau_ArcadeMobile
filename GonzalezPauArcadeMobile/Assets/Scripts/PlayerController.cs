using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 clickedmousePosition;
    private Vector3 clickedplayerPosition;
    private float roadWidth = 10;
    public float slideSpeed = 7f;
    public float moveSpeed = 2f;
    private Animator [] animator;
    private int numPlayers;
    private bool canMove;
    [SerializeField] CrowdSystem crowdSystem;
    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        GameManager.OnGameStateChanged += GameStateChangedCallback;
    }
    private void Update()
    {
        animator = GetComponentsInChildren<Animator>();
        numPlayers = animator.Length;
        if(canMove)
        {
            MoveForward();
            ManageControl();
        }
        

    }
    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
        {
            StartMoving();
        }
        else
        {
            StopMoving();
        }
    }
    private void StartMoving()
    {
        canMove = true;
    }
    private void StopMoving()
    {
        canMove = false;
        for (int i = 0; i < numPlayers; i++)
        {
            animator[i].SetBool("IsRunning", false);
        }
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
            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.returnCrowdRadius(), roadWidth / 2);
            transform.position =  position;  
        }
    }

}
