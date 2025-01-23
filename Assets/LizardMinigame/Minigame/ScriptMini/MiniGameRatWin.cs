using UnityEngine;

public class MiniGameRatWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rat")
        {
            MiniGameWinLose.instance.End(false);
        }
    }
}
