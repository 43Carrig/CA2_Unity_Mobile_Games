using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// References: Unity In-App Purchase https://www.youtube.com/watch?v=j98jrUPHVYw

public class DataManager : Singleton<DataManager>
{
    public Text goldAmountText;

    public GameObject noAdsButton;

    private int goldAmount = 0;

    private bool noAds = false;

    public void AddGold(int amount)
    {
        goldAmount += amount;
        goldAmountText.text = goldAmount.ToString();
    }

    public void RemoveAds()
    {
        noAds = true;
        noAdsButton.SetActive(false);
    }
}
