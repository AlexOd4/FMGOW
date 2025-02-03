using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public static class Name
{
    public static List<string> allScenesToCharge = new List<string> { 
        "JesusCLevel",
        "AlbertoLevel",
        "PabloSLevel",
    };


    #region Anim
    public enum Anim
    {
        None,
        Win,
        Loose,
        PabloS,
        JuanM,
        JesusC,
        FadeOut,
        End
    }

    public static string SearchAnim(Anim anim)
    {
        switch (anim)
        {
            case Anim.None:
                return "";
            case Anim.Win:
                return "Win";
            case Anim.Loose:
                return "Loose";
            case Anim.PabloS:
                return "InstruccionPabloS";
            case Anim.JuanM:
                return "InstruccionJuanM";
            case Anim.JesusC:
                return "InstruccionJesusC";
            case Anim.FadeOut:
                return "FadeOut";
            case Anim.End:
                return "EndGame";
        }
        return "";
    }
    #endregion

}
