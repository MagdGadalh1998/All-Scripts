using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;
    public int coins = 1000;
    public Text coinUI;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        coinUI.text = coins.ToString();
    }

    void Update()
    {
        
    }
    public void UpdteCoinsText()
    {
        coinUI.text = coins.ToString();
    }
}
