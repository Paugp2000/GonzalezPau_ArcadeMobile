using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Slider progresSlider;
    [SerializeField] private TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        progresSlider.value = 0;
        levelText.text = "Level : " + ChunckManager.Instance.getLevel(); ;
        gamePanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgresBar();
    }

    public void PlayButtonPressed()
    {
        GameManager.Instance.setGamestate(GameManager.GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void UpdateProgresBar()
    {
        if (!GameManager.Instance.IsGameState())
        {
            return;
        }
        float progress = 1f - PlayerController.Instance.transform.position.z / ChunckManager.Instance.getFinishLineZPosition(); 
        progresSlider.value = progress;
    }
}
