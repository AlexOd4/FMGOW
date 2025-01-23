using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public static CurrencyManager instance;
    public int startingCurrency;
    public int currency;
    public TMP_Text currencyText;
    public int maxCurrency;
    void Awake()
    {
        instance = this;
        currency = startingCurrency;
        currencyText.text = currency.ToString("000");
    }

    
    public void ChangeCurrency(int addedCurrency)
    {
        currency = Mathf.Clamp(currency + addedCurrency,0,maxCurrency);


        currencyText.text = currency.ToString("000");
    }
}
