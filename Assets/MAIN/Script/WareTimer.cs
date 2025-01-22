using System.Collections;
using UnityEngine;

public class WareTimer : MonoBehaviour
{

    [SerializeField] private float waitTime = 5.0f;

    private void Start()
    {
        Invoke(nameof(TimerEnded), waitTime);
        
    }

    private void Update()
    {
        if (WareManager.Instance.isWin)
        {
            CancelInvoke(nameof(TimerEnded));
        }
    }


    private void TimerEnded() 
    { 
        WareManager.Instance.OnEndLevel(); 
    }
    
}
