using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    Renderer r;
    public Color emissiveColor;
    public bool isSelected;
    public GameObject[] otherOptions;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        r=GetComponentInChildren<Renderer>();
        if(r==null){
            Debug.LogError("couldn't find a renderer component among the children!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            Debug.Log("selected");
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", emissiveColor);
        }
        
    }

    public void Highlight()
    {
        Debug.Log("highlight");
        r.material.EnableKeyword("_EMISSION"); 
        r.material.SetColor("_EmissionColor",emissiveColor);
        handleClick();
    }

    public void NoHighLight()
    {
        Debug.Log("no highlight");
        r.material.SetColor("_EmissionColor",new Color(0.0f,0.0f,0.0f));
    }

    public void handleClick()
    {
        Debug.Log("handleClick");
        if (isSelected)
        {
            isSelected = false;
        }
        else
        {
            //check other options to see if selected
            if (otherOptions.Length > 0)
            {
                isSelected = true;
            }

            else
            {
                int i = otherOptions.Length;
                int j = 0;
                bool noOthers = true;
                while (j < i)
                {
                    HighLight option = otherOptions[j].GetComponent<HighLight>();

                    if (option.isSelected)
                    {
                        noOthers = false;

                    }
                }
                if (noOthers)
                {
                    isSelected = true;
                }


            }

        }
    }
}
