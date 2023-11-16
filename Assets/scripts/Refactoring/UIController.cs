using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public ManagerMeta managerMeta;
    public TextMeshProUGUI txtMonedas;
    public ManagerCoins monedas;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }


    public bool VerificarDash()
    {
        Debug.Log("Entra");

        if (monedas._currentCoins >= 1)
        {
            return true;
        }


            return false;
    }

    public bool VerificarManagerMeta()
    {
        if (monedas._currentCoins > managerMeta.CoinsObjective)
        {
            return true;
        }
        return false;
    }
    public void ActualizarUI()
    {
       txtMonedas.text = monedas._currentCoins.ToString();
    }
}
