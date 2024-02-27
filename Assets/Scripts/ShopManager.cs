using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
   

    public ShopItemSO[] shopItems;
    public GameObject[] shoPanelContiner;
    public ShopPanel[] shopPanelsData;
    public Button[] purchaseBtns;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shoPanelContiner[i].SetActive(true);
        }
        
        LoadPanels();
        CheckPurchaseable();

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnEnable()
    {
        CheckPurchaseable();
    }
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (CurrencySystem.instance.coins >= shopItems[i].baseCost)
                purchaseBtns[i].interactable = true;
            else
                purchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (CurrencySystem.instance.coins >= shopItems[btnNo].baseCost)
        {
            CurrencySystem.instance.coins = 
                                    CurrencySystem.instance.coins - shopItems[btnNo].baseCost;

            CurrencySystem.instance.coinUI.text = 
                                    CurrencySystem.instance.coins.ToString();

            CheckPurchaseable();
            //Unlock Item.
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanelsData[i].titleTxt.text = shopItems[i].title;
            shopPanelsData[i].costTxt.text = shopItems[i].baseCost.ToString();
        }
    }
}
