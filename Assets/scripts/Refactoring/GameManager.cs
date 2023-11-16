using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ManagerMeta _mT;
    public ManagerCoins _mC;
    public GameObject GoalPanel;
    public GameObject WinText;
    public GameObject LoseText;
    void Start()
    {
        _mC.SetUp();
        _mC.AddCoins(15);
        Debug.Log(_mC.CurrentCoints);
    }
    public void checkWin()
    {

        GoalPanel.SetActive(true);
        Debug.Log(_mC.CurrentCoints);
        if (_mC.CurrentCoints < 12)
        {
            WinText.SetActive(false);
            LoseText.SetActive(true);
            Debug.Log("Loser");

        }
        else
        {
            LoseText.SetActive(false);
            WinText.SetActive(true);
            Debug.Log("Winner");
        }
    }

}
