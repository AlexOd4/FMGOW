using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINStartGame : MonoBehaviour
{
    public void StartGameButton()
    {
        WareManager.Instance.wareAnim.Play("FirstScene");
    }

}
