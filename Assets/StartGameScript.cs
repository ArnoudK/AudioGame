using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{

    [SerializeField]
    string start = "start";

    [SerializeField]
    AudioSource audioSourceStart;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(StartAudio),2);
        AudioInputManager.Instance.OnSpeechResult += Instance_OnSpeechResult;
    }

    private void StartAudio()
    {
        audioSourceStart.Play();
    }

    

    private void Instance_OnSpeechResult(object sender, string e)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
