using UnityEngine;

public class SpawnSkibidis : MonoBehaviour
{


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Skibidi"))
        {
            DestroySkibidi(other.gameObject);

            GameManager.instance.MinigameWin = false;
        }
    }

    public void DestroySkibidi(GameObject destruir)
    {
        GameManager.instance.WasShooted = true;
        WareManager.Instance.isWin = true;
        WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.Loose));
        GameManager.instance.ActualPoints = 0;
        Destroy(destruir);
    }
}
