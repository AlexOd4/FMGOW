using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void callWareManager() 
    { 
        WareManager.Instance.loadingScene = SceneManager.LoadSceneAsync(WareManager.Instance.NextScene());
        WareManager.Instance.loadingScene.allowSceneActivation = false;

        switch (WareManager.Instance.loadedScene)
        {
            case "TestScene":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.PabloS));
                return;
            case "TestScene01":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.PabloS));
                return;
            case "TestScene02":
                WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.PabloS));
                return;
        }
    }

    public void animationEnded()
    {
        WareManager.Instance.animationIsEnded = true;
    }

    void ResetAllBools() 
    { 
        foreach (AnimatorControllerParameter parameter in WareManager.Instance.wareAnim.parameters) 
        { 
            if (parameter.type == AnimatorControllerParameterType.Bool) 
            {
                WareManager.Instance.wareAnim.SetBool(parameter.name, false); 
            } 
        } 
    }

}
