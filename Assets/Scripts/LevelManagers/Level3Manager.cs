using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    bool matching;

    private int minimumNumber=100,maximumNumber=1000;
    private int levelCorrectNumber;

    [SerializeField]
    int[] levelCorrectNumbers;

    [SerializeField] TextMeshProUGUI levelCorrectNumberText;
    [SerializeField] NumberChange[] levelNumbers;

    private void Start() {
        LevelManager.Instance.OnLevelAction += LevelAction;

        StartCoroutine("SetLevel");
    }

    IEnumerator SetLevel() {
        float timeToWait = 0f;

        yield return new WaitForSeconds(timeToWait);

        SetLevelCorrectNumber();
    }

    private void OnDisable() {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }

    private void LevelAction(object sender, EventArgs e) {

        CheckForLevelEnd();
    }

    void SetLevelCorrectNumber() {

        int levelNumbers = 3;
        levelCorrectNumber = UnityEngine.Random.Range(minimumNumber,maximumNumber);
        levelCorrectNumberText.text = levelCorrectNumber.ToString();

        //set level correct numbers list
        string correctNumberString = levelCorrectNumber.ToString();
        for (int i=0;i< levelNumbers;i++) {
            levelCorrectNumbers[i] = int.Parse(correctNumberString[i].ToString());
        }

    }

    private void CheckForLevelEnd() {
        matching = true;

        for (int i=0;i<levelCorrectNumbers.Length;i++) {
            if (levelCorrectNumbers[i]!= levelNumbers[i].GetCurrentNumber()) {
                matching = false;
                break;
            }
        }

        //check if all matched
        if (matching) {
            Debug.Log("Level success");
            LevelManager.Instance.OpenDoor();
        } else {
            Debug.Log("Level Loss");
        }
    }
}
