using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField]private AudioSource hitGooddoorSound;
    [SerializeField]private AudioSource hitBaddoorSound;
    [SerializeField]private AudioSource deathRunnerSound;
    [SerializeField] private AudioSource victorySound;
    private bool soundsCanPlay = true;
    void Start()
    {
        CrowdSystem.onGoodDoorSound += PlayGoodDoorSound;
        CrowdSystem.onBadDoorSound += PlayBadDoorSound; 
        EnemyController.deathRunnerSound += PlayDeathRunnerSound;
        PlayerDetection.victorySoundEvent += PlayVictorySound;
    }
    private void OnDestroy()
    {
        CrowdSystem.onGoodDoorSound -= PlayGoodDoorSound;
        CrowdSystem.onBadDoorSound -= PlayBadDoorSound;
        EnemyController.deathRunnerSound -= PlayDeathRunnerSound;
        PlayerDetection.victorySoundEvent -= PlayVictorySound;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayGoodDoorSound()
    {
        if (soundsCanPlay)
            hitGooddoorSound.Play();
     
    }
    private void PlayBadDoorSound()
    {
        if (soundsCanPlay)
        hitBaddoorSound.Play();
    }
    private void PlayDeathRunnerSound()
    {
        if (soundsCanPlay)
        deathRunnerSound.Play();    
    }
    private void PlayVictorySound()
    {
        if (soundsCanPlay)  
        victorySound.Play();
    }

    public void disableEnableAllSounds(bool isOn)
    {
        soundsCanPlay = isOn;   
    }

}
