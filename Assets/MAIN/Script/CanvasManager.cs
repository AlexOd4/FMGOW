using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void callWareManager() 
    { 
        SceneManager.LoadSceneAsync(WareManager.Instance.NextScene()); 
    }
}
