using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Toggle VolumeToggle;
    [SerializeField] private SoundsManager SoundsManager;

    private void Update()
    {
        VolumeToggle.onValueChanged.AddListener(SoundsManager.disableEnableAllSounds);
    }
    public void SalirDelJuego()
    {
        Application.Quit(); 
    }
}
