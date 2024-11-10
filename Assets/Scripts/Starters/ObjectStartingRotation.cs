using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStartingRotation : MonoBehaviour
{
    int currentDirection; //0 up , 1 right , 2 down , 3 right

    [SerializeField] int numberOfDirections;

    private void Awake() {
        SetCorrectStartingRotation();
    }


    private void SetCorrectStartingRotation(){
        if (numberOfDirections==2) {
            SetRandomStartingRotationFor2Directions();
        } else if (numberOfDirections==4) {
            SetRandomStartingRotationFor4Directions();
        }
    }


    private void SetRandomStartingRotationFor2Directions() {

        int maxDirections = 2;

        currentDirection = UnityEngine.Random.Range(0, maxDirections);

        Vector3 rot = this.transform.eulerAngles;

        switch (currentDirection) {
            case 0:
                rot.z = 0f;
                break;
            case 1:
                rot.z = 180f;
                break;
        }

        this.transform.eulerAngles = rot;

    }

    private void SetRandomStartingRotationFor4Directions() {

        int maxDirections = 4;

        currentDirection = UnityEngine.Random.Range(0, maxDirections);

        Vector3 rot = this.transform.eulerAngles;

            switch (currentDirection) {
                case 0: rot.z = 0f;
                    break;
                case 1:rot.z = -90f;
                    break;
                case 2:rot.z = 180f;
                    break;
                case 3:rot.z = 90f;
                    break;
            }

        this.transform.eulerAngles = rot;

        }

    public int GetStartingRotationDirectionIndex() {
        return currentDirection;
    }


    }

