using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Manager : MonoBehaviour
{
    bool matching;
    [SerializeField] Rotate_Neighbour_Up_Down[] levelMatches;


    [SerializeField]
    GameObject[] referenceMatches;
    [SerializeField] int[] correctLevelMatchesIndexes;

    private void Start() {
        LevelManager.Instance.OnLevelAction += LevelAction;

        StartCoroutine("SetLevel");

    }

    IEnumerator SetLevel() {
        float timeToWait = 1f;

        yield return new WaitForSeconds(timeToWait);

        SetCorrectLevelMatches();
    }
    private void OnDisable() {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }

    private void LevelAction(object sender, EventArgs e) {

        CheckMatchDirections();
    }


    private void SetCorrectLevelMatches() {
        for (int i=0;i<referenceMatches.Length;i++) {
            correctLevelMatchesIndexes[i] = referenceMatches[i].GetComponent<ObjectStartingRotation>().GetStartingRotationDirectionIndex();
        }
    }

    private void CheckMatchDirections() {

        matching = true;

        for (int i=0;i<levelMatches.Length;i++) {

            if (correctLevelMatchesIndexes[i]!= levelMatches[i].GetDirectionIndex()) {
                matching = false;
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
