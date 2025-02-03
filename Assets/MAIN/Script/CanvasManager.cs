using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void callWareManager() 
    { 
        WareManager.Instance.loadingScene = SceneManager.LoadSceneAsync(WareManager.Instance.NextScene());
        WareManager.Instance.loadingScene.allowSceneActivation = true;

        switch (WareManager.Instance.loadedScene)
        {
            case "AlbertoLevel":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.JesusC));
                return;
            case "PabloSLevel":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.PabloS));
                return;
            case "JesusCLevel":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.JesusC));
                return;
            case "EndGame":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.End));
                return;
        }
    }

    public void FirstScene()
    {
        WareManager.Instance.loadingScene = SceneManager.LoadSceneAsync(Name.allScenesToCharge[0]);
        WareManager.Instance.loadingScene.allowSceneActivation = true;
        
    }

    public void animationEnded()
    {
        WareManager.Instance.animationIsEnded = true;
    }

    //void ResetAllBools() 
    //{ 
    //    foreach (AnimatorControllerParameter parameter in WareManager.Instance.wareAnim.parameters) 
    //    { 
    //        if (parameter.type == AnimatorControllerParameterType.Bool) 
    //        {
    //            WareManager.Instance.wareAnim.SetBool(parameter.name, false); 
    //        } 
    //    } 
    //}

}
