using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public CrowdSystem crowdSystem;
    public static Action victorySoundEvent;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameState())
        {
            DetectDoors();
        }
        
    }

    private void DetectDoors()
    {
        Collider[] detectColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectColliders.Length; i++)
        {
            if (detectColliders[i].TryGetComponent(out Doors doors))
            {
                {
                    Debug.Log("Has chocado con una puerta");

                    int bonusAmount = doors.getBonusAmount(transform.position.x);
                    BonusType bonustype = doors.getBonusType(transform.position.x);

                    doors.Disable();

                    crowdSystem.ApplyBonus(bonusAmount, bonustype);
                }
            }else if (detectColliders[i].tag == "Finish")
            {
                Debug.Log("Has llegado a la meta");

                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                //SceneManager.LoadScene(0);
                victorySoundEvent?.Invoke();
                GameManager.Instance.setGamestate(GameManager.GameState.LevelComplete); 
            }
        }
    }
}
