using UnityEngine;

public class LizardObject : MonoBehaviour
{

    public LizardScriptableObject lizard;

    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = lizard.lizardImage;
        spriteRenderer.color = new Color(1,1,1,0.5f);

    }

}
