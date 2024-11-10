using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class Level1Manager : MonoBehaviour
{

    bool matching;
    [SerializeField]
    int[] correctDirections;
    [SerializeField] RotateRight90[] levelMatches;

    [SerializeField] GameObject[] references;

    private void Start() {
        LevelManager.Instance.OnLevelAction += LevelAction;

        StartCoroutine("SetLevel");
    }

    IEnumerator SetLevel() {

        float timeToWait = 1f;

        yield return new WaitForSeconds(timeToWait);
        SetRandomReferences  ();
    }
    private void OnDisable() {
        LevelManager.Instance.OnLevelAction -= LevelAction;
    }

    private void LevelAction(object sender,EventArgs e) {

        CheckForLevelEnd();
    }

    private void CheckForLevelEnd() {
        matching = true;
        for (int i = 0; i < levelMatches.Length; i++) {
            if (correctDirections[i] != levelMatches[i].GetCurrentDirection()) {
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

   //Random Reference
   private void SetRandomReferences() {

        for (int i=0;i<references.Length;i++) {
            correctDirections[i] = references[i].GetComponent<ObjectStartingRotation>().GetStartingRotationDirectionIndex();
        }

    }




}
