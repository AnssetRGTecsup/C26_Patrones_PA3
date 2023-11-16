using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject creditsPanel;

    private void Start()
    {
        ActivePanels(true, false, false);
    }

    private void ActivePanels(bool menuActive, bool infoActive, bool creditsActive)
    {
        menuPanel.SetActive(menuActive);
        infoPanel.SetActive(infoActive);
        creditsPanel.SetActive(creditsActive);
    }

    public void ReturnToMenu()
    {
        ActivePanels(true, false, false);
    }

    public void OpenInfoPanel()
    {
        ActivePanels(false, true, false);
    }

    public void OpenCreditsPanel()
    {
        ActivePanels(false, false, true);
    }

    public void ExitGame()
    {

    }
}
