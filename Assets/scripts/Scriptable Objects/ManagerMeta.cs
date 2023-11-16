using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meta Manager", menuName = "ScriptableObjects/Meta Manager", order = 1)]
public class ManagerMeta : ScriptableObject
{
    [SerializeField] public int CoinsObjective;

    public bool CheckWin(int currentCoins)
    {
        return CoinsObjective <= currentCoins;
    }
}
