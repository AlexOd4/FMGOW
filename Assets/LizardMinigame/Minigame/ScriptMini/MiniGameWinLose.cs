using UnityEngine;

public class MiniGameWinLose : MonoBehaviour
{
    public static MiniGameWinLose instance;
    private bool won;
    private void Awake()
    {
        instance = this;
    }

    public void End(bool win)
    {
        WareManager.Instance.isWin = win;
        if(win)
        {
            print("winner");
            WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.Win));
        } else
        {
            print("loser");
            WareManager.Instance.levelPoints = 0;
            WareManager.Instance.wareAnim.Play(Name.SearchAnim(Name.Anim.Loose));

        }
        WareManager.Instance.OnEndLevel();

    }
}
