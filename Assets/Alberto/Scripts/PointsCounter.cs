using UnityEngine;
using System.Collections;

public class PointsCounter : MonoBehaviour
{
    private GameObject toiletCompleted;

    public void Start()
    {
        toiletCompleted = transform.parent.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Skibidi"))
        {
            DestroyToilet();
            Destroy(other.gameObject);
        }
    }

    public void DestroyToilet()
    {
        GameManager.instance.MinigameWin = true;
        GameManager.instance.ActualPoints += 1;
        GameManager.instance.WasPointed = true;
        GameManager.instance.WasShooted = true;
        WareManager.Instance.isWin = true;
        WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.Win));
        Destroy(toiletCompleted);
    }

}
