using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
    [SerializeField] private TextMeshProUGUI stageTxt;
    public int currentStageIndex = 1;
    private int roundNum = 1;
    public float spawnInterval = 1f;

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
            UpdateStageUI();
            yield return new WaitForSeconds(spawnInterval);

        }
    }

    private void UpdateStageUI()
    {
        stageTxt.text = $"{currentStageIndex}";
    }
}