using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WareManager : MonoBehaviour
{

    //Canvas Prefab and canvas instance objects
    [SerializeField] private GameObject myCanvasManagerObject;
    private GameObject canvasObject;
    
    //Animator vars
    public Animator wareAnim;
    public bool animationIsEnded;

    //Loading vars
    public AsyncOperation loadingScene;
    public string loadedScene;
    private bool isSceneLoaded;

    //The highest Score done in a Local PC
    public int highScore;

    //Run's Score
    public int warePoints;
    public int levelPoints;
    
    public bool isWin;

    #region SET UP WareManager
    public static WareManager Instance;
    

    private void Awake()
    {

        GameObject singletonObject = this.gameObject;
        DontDestroyOnLoad(singletonObject);
        if (Instance == null) Instance = this;

        Load();

        Shuffle(Name.allScenesToCharge);
        print(Name.allScenesToCharge[0]);
        canvasObject = Instantiate(myCanvasManagerObject, this.gameObject.transform);
        wareAnim = canvasObject.GetComponent<Animator>();
    }

    private WareManager() { }
    #endregion


    #region Save and Load Function
    /// <summary>
    /// Guarda los datos usando saveSystem
    /// </summary>
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    /// <summary>
    /// Carga los datos guardados
    /// </summary>
    public void Load()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            Save();
            data = SaveSystem.LoadPlayer();
        }

        highScore = data.globalScore;
    }
    #endregion


    #region Unity Function 

    private void Update()
    {
        if (isSceneLoaded && animationIsEnded)
        {
            wareAnim.Play("FadeOut");
            isSceneLoaded = false; animationIsEnded = false;
        }
    }

    public void OnLevelWasLoaded(int level)
    {
        isSceneLoaded = true;
        loadingScene.allowSceneActivation = true;
    }
    #endregion

    #region Scene function
    public string NextScene()
    {
        if (Name.allScenesToCharge.Count == 0)
        {
            loadedScene = "endGame";
            return "endGame";
        }
        loadedScene = Name.allScenesToCharge[0];
        Name.allScenesToCharge.RemoveAt(0);
        return loadedScene;
    }

    public void OnEndLevel()
    {
        print("TIMER IS ENDED");
        UpdateScore();
        NextScene();
    }
    
    
    
    #endregion

    public void UpdateScore()
    {
        warePoints += levelPoints;
        if (warePoints > highScore)
        {
            highScore = warePoints;
            Save();
        }
    }


    #region Private void
    private void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random(); 
        int n = list.Count; 
        while (n > 1) 
        { 
            n--;
            int k = rng.Next(n + 1); 
            T value = list[k]; 
            list[k] = list[n]; 
            list[n] = value; 
        }
    }
    #endregion
}
