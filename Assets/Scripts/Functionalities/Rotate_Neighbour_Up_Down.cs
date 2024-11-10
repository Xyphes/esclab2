using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rotate_Neighbour_Up_Down : MonoBehaviour
{
    public bool canRotateItself;

    float upMatch=0f,downMatch=180f;

    int currentDirection;

    [SerializeField] Rotate_Neighbour_Up_Down leftNeighbour;
    [SerializeField] Rotate_Neighbour_Up_Down rightNeighbour;

    private Button currentButton;

    //public bool changeRight=true;

    private void Start() {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(ChangeNeighbourDirection);

        GetMatchDirection();

    }

    private void GetMatchDirection() {
        currentDirection = GetComponent<ObjectStartingRotation>().GetStartingRotationDirectionIndex();
    }

    private void ChangeNeighbourDirection() {

        if (currentDirection==0) {
            rightNeighbour.ChangeCurrentDirection();
        } else {
            leftNeighbour.ChangeCurrentDirection();
        }

        if (canRotateItself) {
            ChangeCurrentDirection();
        }


        //event 
        LevelManager.Instance.ActionMade();

    }
    public void ChangeCurrentDirection() {

        Vector3 rot = this.transform.eulerAngles;

        if (currentDirection==0) {
            currentDirection = 1;
            rot.z = downMatch;
        }else if (currentDirection==1) {
            currentDirection = 0;
            rot.z=upMatch;
        }
        this.transform.eulerAngles=rot;
    }

    public int GetDirectionIndex() {
        return currentDirection;
    }

    
}
