using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToMatchHead : MonoBehaviour
{
    public bool moveComplete = false;

    public GameObject headObject;
    public float timeUntilMove = 5.0f;

    public GameObject startUI;
    public GameObject[] lights;


    // Start is called before the first frame update
    void Start()
    {
        startUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveComplete)
        {
            startUI.SetActive(false);
            foreach (GameObject light in lights)
            {
      
                light.SetActive(true);
            }
            return; //we are done, no need to do anything else!
        }

        if (Time.time > timeUntilMove) //after some seconds lets move objects!
        {
            Debug.Log("we are moving the world to match the users head NOW!");

            Vector3 newPos = this.headObject.transform.position;
            newPos.y = 0; //don't adjust for y (height)

            this.transform.position = newPos; //set the position of the parent that holds all the environmental objects. 

            moveComplete = true;

        }

    }
}

