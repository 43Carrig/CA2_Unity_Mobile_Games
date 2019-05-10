using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// References: Unity In-App Purchase https://www.youtube.com/watch?v=j98jrUPHVYw

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        Gold50,
        Gold100,
        NoAds
    }

    public int money;
    
    public ItemType itemType;

    public Text priceText;
    

    private string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        defaultText = priceText.text;
        //    StartCoroutine(LoadPriceRoutine());
    }

    private void Update()
    {
        priceText.text = money.ToString();
    }

    /*public void ClickBuy()
    {
        switch (itemType)
        {
            case ItemType.Gold50:
                IAPManager.Instance.Buy50Gold();
                break;
            
            case ItemType.Gold100:
                IAPManager.Instance.Buy100Gold();
                break;
            
            case ItemType.NoAds:
                IAPManager.Instance.BuyNoAds();
                break;
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.Instance.IsInitialized())
            yield return null;

        string loadedPrice = "";
        
        switch (itemType)
        {
            case ItemType.Gold50:
                loadedPrice = IAPManager.Instance.GetProducePriceFromStore(IAPManager.Instance.GOLD_50);
                break;
            
            case ItemType.Gold100:
                loadedPrice = IAPManager.Instance.GetProducePriceFromStore(IAPManager.Instance.GOLD_100);
                break;
            
            case ItemType.NoAds:
                loadedPrice = IAPManager.Instance.GetProducePriceFromStore(IAPManager.Instance.NO_ADS);
                break;
        }

        priceText.text = defaultText + " " + loadedPrice; 
    }*/

    public void add50Gold()
    {
        money += 50;
    }

    public void add100Gold()
    {
        money += 100;
    }
}
