using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObjectLoadScene : StoryTestScript.StoryObject
{
    [SerializeField]
    GameManager.REGISTEREDSCENES sceneToLoad;

    [SerializeField]
    float delay;

    public override void TriggerAction()
    {
        GameManager.Instance.LoadScene(sceneToLoad);
    }
}
