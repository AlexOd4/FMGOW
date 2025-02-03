using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using NUnit.Framework;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{

    private int actualPoints = 0;
    private int maxPoints = 0;

    public TMP_Text actualPointsText;
    public TMP_Text maxPointsText;
    private bool wasPointed;
    private bool wasShooted;

    public GameObject skibidiPrefab;
    public GameObject skibidiSpawn;

    public GameObject toiletPrefab;
    private GameObject[] spawnPoints;

    public static GameManager instance;

    private bool minigameWin;

    public int ActualPoints { get => actualPoints; set => actualPoints = value; }
    public bool WasPointed { get => wasPointed; set => wasPointed = value; }
    public bool WasShooted { get => wasShooted; set => wasShooted = value; }
    public int MaxPoints { get => maxPoints; set => maxPoints = value; }
    public bool MinigameWin { get => minigameWin; set => minigameWin = value; }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        GenerateToilet();
    }

    private void Update()
    {
        actualPointsText.text = ActualPoints.ToString();

        maxPointsText.text = MaxPoints.ToString();

        if(actualPoints > maxPoints)
        {
            maxPoints = actualPoints;
        }

        if(wasPointed == true)
        {
            GenerateToilet();
            wasPointed = false;
        }

        if(WasShooted == true)
        {
            GenerateSkibidi();
            WasShooted = false;
        }
    }

    private int PreviousAleatorio = 0;

    public void GenerateToilet()
    {
        int indexAleatorio;
        do
        {
            indexAleatorio = Random.Range(0, spawnPoints.Length);
        } while (PreviousAleatorio == indexAleatorio);

        GameObject spawnPoint = spawnPoints[indexAleatorio];

        Instantiate(toiletPrefab, spawnPoint.transform.position, toiletPrefab.transform.rotation);

        PreviousAleatorio = indexAleatorio;
    }

    public void GenerateSkibidi()
    {
        Collider[] objetosCercanos = Physics.OverlapSphere(skibidiSpawn.transform.position, 0.5f);

        if (objetosCercanos.Length == 0)
        {
            Instantiate(skibidiPrefab, skibidiSpawn.transform.position, skibidiPrefab.transform.rotation);
        }
    }
}
