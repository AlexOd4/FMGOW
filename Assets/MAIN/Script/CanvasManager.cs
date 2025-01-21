using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void callWareManager() 
    { 
        WareManager.Instance.LoadingScene = SceneManager.LoadSceneAsync(WareManager.Instance.NextScene());
        WareManager.Instance.LoadingScene.allowSceneActivation = false;

        switch (WareManager.Instance.loadedScene)
        {
            case "TestScene":
                WareManager.Instance.WareAnim.Play("");
                return;
            case "TestScene01":
                WareManager.Instance.WareAnim.Play("");
                return;
            case "TestScene02":
                WareManager.Instance.WareAnim.Play("");
                return;
        }
    }

    void ResetAllBools() 
    { 
        foreach (AnimatorControllerParameter parameter in WareManager.Instance.WareAnim.parameters) 
        { 
            if (parameter.type == AnimatorControllerParameterType.Bool) 
            {
                WareManager.Instance.WareAnim.SetBool(parameter.name, false); 
            } 
        } 
    }

}
