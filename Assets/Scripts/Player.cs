using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    int currentDoorIndex;
    public Boolean inGame;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a specific tag, for example "Player"
        if (other.CompareTag("Door"))
        {
            inGame = true;
            // Add your custom logic here
            Debug.Log("Player has entered the trigger zone!");
            //getting the door index in the game
            Debug.Log(other.gameObject.GetComponentInParent<Door>().GetDoorIndex());

            currentDoorIndex = other.gameObject.GetComponentInParent<Door>().GetDoorIndex();

            DoorToOpen door = other.gameObject.GetComponentInParent<DoorToOpen>();

            LevelManager.Instance.SetDoorIndexPuzzle(currentDoorIndex,door);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object entering the trigger has a specific tag, for example "Player"
        if (other.CompareTag("Door"))
        {
            // Add your custom logic here
            Debug.Log("Player has exit the trigger zone!");
            currentDoorIndex = -1;

            LevelManager.Instance.PlayerExitZone();
            inGame = false;
        }
    }
}
