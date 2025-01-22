using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int globalScore;    

    /// <summary>
    /// Data to be saved form the gameManager
    /// </summary>
    /// <param name="gameManager"></param>
    public PlayerData (WareManager gameManager)
    {

        globalScore = gameManager.highScore;

    }

}
