using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public event EventHandler OnLevelAction; // the player made a move

    public bool firstPuzzle=true;

    public int actionTriggererIndex;
    public GameObject actionTriggerer; //the object who triggerred the event

    public static LevelManager Instance;

    public List<GameObject> puzzles = new List<GameObject>();

    public GameObject currentPuzzle,puzzlesParent;

    public DoorToOpen currentDoor;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

   public void ActionMade() {
        OnLevelAction?.Invoke(this, EventArgs.Empty);
    }

    public void SetDoorIndexPuzzle(int index,DoorToOpen cDoor)
    {
        GameObject puzzle = Instantiate(puzzles[index],Vector3.zero,Quaternion.identity);
        puzzle.transform.SetParent(puzzlesParent.transform);

        currentPuzzle= puzzle;
        currentDoor = cDoor;

        if (firstPuzzle)
        {
            firstPuzzle = false;
            PlayerExitZone();
        }

    }
    public void PlayerExitZone()
    {
        Destroy(currentPuzzle);
    }

    public void OpenDoor()
    {
        Destroy(currentPuzzle);

        currentDoor.IsOpen();
    }
}
