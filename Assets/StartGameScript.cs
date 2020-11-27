using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameScript : MonoBehaviour
{

    [SerializeField]
    string startKeyWord = "start";

    [SerializeField]
    string storySceneName;

    [SerializeField]
    AudioSource audioSourceStart;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceStart.PlayDelayed(0.5f);

        AudioInputManager.Instance.OnSpeechResult += Instance_OnSpeechResult;
    }




    private void Instance_OnSpeechResult(object sender, string e)
    {
        if (e.Contains(startKeyWord))
        {
            SceneManager.LoadScene(storySceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
