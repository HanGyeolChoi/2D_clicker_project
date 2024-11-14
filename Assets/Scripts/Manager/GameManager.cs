using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{

    public int currentStageIndex = 1;
    public int roundIndex = 1;
    public float spawnInterval = 1f;

    public event Action OnInitialize;
    private void Start()
    {
        //if(savefile)
        //currentStageIndex = read save file
        StartCoroutine(StartStage(currentStageIndex));
    }

    IEnumerator StartStage(int stage)
    {
        while (true)
        {
            OnInitialize?.Invoke();
            yield return new WaitForSeconds(spawnInterval);
            
        }
    }

    

}