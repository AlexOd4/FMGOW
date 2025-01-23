using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniGameLogic : MonoBehaviour
{
    public float timeBeforeAttack;
    //Max five
    public int ratAmount;
    //if random is on it will create from 0 to random
    public bool random;
    [SerializeField]
    private Transform ratParent;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject ratObj;

    private List<RatBasicBehaviour> rats = new();
    private bool ableToWin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int realRatamount = 0;
        if(random)
        {
            realRatamount = Random.Range(0, ratAmount);
        } else
        {
            realRatamount = ratAmount;
        }
        CurrencyManager.instance.currency = realRatamount * 75;
        CurrencyManager.instance.ChangeCurrency(0);
        int spawnedRats = 0;
        List<Transform> usedSpawnPoint = new();
        while(spawnedRats < realRatamount)
        {
            Transform chosenTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if (!usedSpawnPoint.Contains(chosenTransform))
            {
                RatBasicBehaviour behaviour = Instantiate(ratObj, chosenTransform.position,Quaternion.identity,ratParent).GetComponent<RatBasicBehaviour>();
                behaviour.speed = 0;
                rats.Add(behaviour);
                usedSpawnPoint.Add(chosenTransform);
                spawnedRats++;
            }
        }


        StartCoroutine(StartAttack());


    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(timeBeforeAttack);
        foreach (RatBasicBehaviour rat in rats)
        {
            rat.speed = 1;
        }
        ableToWin = true;
    }


    private void Update()
    {
        if(ableToWin && ratParent.childCount <= 0)
        {
            MiniGameWinLose.instance.End(true);
        }
    }
}
