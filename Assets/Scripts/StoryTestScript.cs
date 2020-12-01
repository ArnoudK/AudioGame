using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTestScript : MonoBehaviour
{

    [SerializeField]
    public StoryObject[] storyObjects;



    // Start is called before the first frame update
    void Start()
    {
        AudioInputManager.Instance.OnSpeechResult += Instance_OnSpeechResult;
    }

    private void Instance_OnSpeechResult(object sender, string e)
    {
        foreach (StoryObject so in storyObjects)
        {
            if (e.Contains(so.triggerKeyWord))
            {
                so.Triggered();
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract class StoryObject : MonoBehaviour
    {

        [SerializeField]
        AudioSource playSound;

        public string triggerKeyWord;
        public string notifyKeyWord;

        public void Triggered()
        {
            if (playSound != null)
            {
                playSound.PlayDelayed(0.5f);
            }
            TriggerAction();
        }

        public abstract void TriggerAction();

    }

}
