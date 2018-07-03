using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour {
    private static CoinsManager instance;
    private int maxCoinLevel = 0;
    private int currentCoinLevel = 0;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxCoinLevel = Object.FindObjectsOfType<Coin>().Length;
    }
    public int CoinsTotal
    {
        get {
            if (currentCoinLevel > maxCoinLevel)
                return maxCoinLevel;
            return maxCoinLevel;
        }
    }
    public int CurrentCoins
    {
        get
        {
            return currentCoinLevel;
        }
    }
    public void AddCoin()
    {
        currentCoinLevel++;
    }

    public static CoinsManager Instance
    {
        get
        {
            return instance;
        }
    }

}
