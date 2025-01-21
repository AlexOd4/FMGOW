using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WareManager : MonoBehaviour
{
    [SerializeField] private GameObject myCanvasManagerObject;
    private GameObject canvasObject;
    public Animator WareAnim;
    public AsyncOperation LoadingScene;
    public string loadedScene;

    private bool isSceneLoaded;
    private bool animationIsEnded;
    #region SET UP WareManager
    public static WareManager Instance;
    

    private void Awake()
    {

        GameObject singletonObject = this.gameObject;
        DontDestroyOnLoad(singletonObject);
        if (Instance == null) Instance = this;


        Shuffle(Name.allScenesToCharge);
        print(Name.allScenesToCharge[0]);
        canvasObject = Instantiate(myCanvasManagerObject, this.gameObject.transform);
        WareAnim = canvasObject.GetComponent<Animator>();
    }

    private WareManager() { }
    #endregion


    private void Start()
    {
        WareAnim.Play(Name.SearchAnim(Name.Anim.FadeIn));
    }

    private void Update()
    {
        if (isSceneLoaded && animationIsEnded)
        {
            WareAnim.Play("FadeOut");
            isSceneLoaded = false;
        }
    }

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

    public void OnLevelWasLoaded(int level)
    {
        isSceneLoaded = true;
        LoadingScene.allowSceneActivation = true;
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
