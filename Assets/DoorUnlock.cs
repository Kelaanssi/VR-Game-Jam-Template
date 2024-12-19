using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class DoorUnlock : MonoBehaviour
{

    //public TutorialProgression tutorialProgression;

    private Door scriptB;

    // Start is called before the first frame update
    void Start()
    {
        scriptB = transform.parent.parent.parent.GetComponent<Door>();

        scriptB.KeyUpdate(0f);

        //if (tutorialProgression != null)
        //{
            //tutorialProgression.KeyInserted();
        //}
        //else
        //{
            //Debug.LogWarning("ScriptA reference is missing!");
        //}
    }
}
