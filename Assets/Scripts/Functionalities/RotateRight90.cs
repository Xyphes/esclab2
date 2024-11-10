using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RotateRight90 : MonoBehaviour
{
    private Button currentButton;

    public int currentDirection = 0;
    private int maxDirection = 3;

    private void Start() {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(RotateRight90Degrees);

        GetStartingRotationDirection();
    }


    private void GetStartingRotationDirection() {

        currentDirection = GetComponent<ObjectStartingRotation>().GetStartingRotationDirectionIndex();

    }

    private void RotateRight90Degrees() {

        float rotateAmount = 90f;
        Vector3 rot = this.transform.eulerAngles;
        rot.z -= rotateAmount;
        this.transform.transform.eulerAngles = rot;

        //direction
        currentDirection++;
        if (currentDirection> maxDirection) {
            currentDirection=0;
        }

        //event 
        LevelManager.Instance.ActionMade();
    }

    public int GetCurrentDirection() { 
        return currentDirection;
    }
}
