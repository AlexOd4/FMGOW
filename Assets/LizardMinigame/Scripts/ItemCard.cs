using TMPro;
using UnityEngine;

public class ItemCard : MonoBehaviour
{
    public GameObject item;
    public TMP_Text priceText;
    private LizardObject lizardObjectReference;
    private SpriteRenderer backGround;
    private SpriteRenderer portraitSprite;
    public bool canBuy;
    public bool checkCanBuy = true;
    private void Start()
    {
        backGround = GetComponent<SpriteRenderer>();
        portraitSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        lizardObjectReference = item.GetComponent<LizardObject>();
        if(priceText != null)
        {
            priceText.text = lizardObjectReference.lizard.lizardPrice.ToString("000");
        }
        portraitSprite.sprite = lizardObjectReference.lizard.lizardImage;
    }

    private void Update()
    {
        if (checkCanBuy) 
        {
            canBuy = CurrencyManager.instance.currency >= lizardObjectReference.lizard.lizardPrice;
            CanBuyShow(CurrencyManager.instance.currency >= lizardObjectReference.lizard.lizardPrice);
        }
    }

    private void CanBuyShow(bool can)
    {
        if (can)
        {
            backGround.color = Color.white;
            portraitSprite.color = Color.white;
        } else
        {
            backGround.color = new Color(0.5f, 0.5f, 0.5f,1);
            portraitSprite.color = new Color(0.5f, 0.5f, 0.5f, 1);


        }
    }
}
