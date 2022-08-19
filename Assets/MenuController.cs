using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject questPanel;
    public GameObject rewardPanel;
    public GameObject inventoryPanel;
    public GameObject dialoguePanel;
    public GameObject pausePanel;
    public GameObject deathPanel;
    
    public bool isPanelOpen = false;
    public bool isPanelLocked = false;
    public bool paused = false;

    public HealthBar healthSlider;

    void Update()
    {
        // Automatic Menus
        if(healthSlider.slider.value < 0.1f)
            TriggerDeath();
        // Controlled Menus
        if(Input.GetKeyDown(KeyCode.E))
            InventoryToggle();
        if(Input.GetKeyDown(KeyCode.Escape))
            PauseToggle();    
    }

    void PauseToggle()
    {
        if(!isPanelLocked)
        {
            paused = !pausePanel.active;

            pausePanel.SetActive(paused);
            Time.timeScale = Convert.ToSingle(!paused);
        }
    }

    void InventoryToggle()
    {
        if(!isPanelLocked)
        {
            isPanelOpen = !isPanelOpen;
            inventoryPanel.SetActive(isPanelOpen);
        }
    }

    void TriggerDeath()
    {
        CloseAllPanels();
        deathPanel.SetActive(true);

        isPanelOpen = true;
        isPanelLocked = true;
    }

    void CloseAllPanels()
    {
        questPanel.SetActive(false);
        rewardPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        dialoguePanel.SetActive(false);
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }
}
