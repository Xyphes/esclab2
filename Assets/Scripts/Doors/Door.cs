using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int index;


    public GameObject doorToOpen;

    public int GetDoorIndex()
    {
        return (index);
    }
}