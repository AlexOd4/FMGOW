using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public static class Name
{
    public static List<string> allScenesToCharge = new List<string> { 
        "TestScene",
        "TestScene01",
        "TestScene02",
    };


    #region Anim
    public enum Anim
    {
        None,
        FadeIn,
        FadeOut,
    }

    public static string SearchAnim(Anim anim)
    {
        switch (anim)
        {
            case Anim.None:
                return "";
            case Anim.FadeOut:
                return "FadeOut";
            case Anim.FadeIn:
                return "FadeIn";
        }
        return "";
    }
    #endregion

}
