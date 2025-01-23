using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private Image endPanel;
    [SerializeField]
    private TMP_Text endText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangePanel(Color newColor, string newText, bool turnOn = true)
    {
        endPanel.color = newColor;
        endText.text = newText;
        if (turnOn)
        {
            endPanel.gameObject.SetActive(true);
        }
    }
}
