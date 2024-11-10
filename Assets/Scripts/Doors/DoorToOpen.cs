using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToOpen : MonoBehaviour
{
    float maxY;
    float offsetY=3.5f;
    float openSpeed=10f;
    public bool open;
    private bool timeAdded; 
    void Start()
    {
        maxY = this.transform.position.y + offsetY;
    }
    void Update()
    {
        if (open)
        {
            if (!timeAdded)
            {
                EventManager.OnTimerUpdate(10.0f);
                timeAdded = true;
            }
            if (this.transform.position.y<=maxY)
            {
                Vector3 temp = this.transform.position;
                temp.y += 0.001f * openSpeed;
                this.transform.position = temp;
                if (this.transform.position.y==maxY)
                {
                    timeAdded = false;
                }
            }
            else
            {
                open = false;
                Debug.Log("not less" + this.transform.position.y);
            }
        }
    }

    public void IsOpen()
    {
        Debug.Log("opening");
        open= true;
    }
}
