using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class AudioInputManager : MonoBehaviour
{



    private DictationRecognizer m_DictationRecognizer;
    [SerializeField]
    Text m_Recognitions;

    [SerializeField]
    Text m_Hypotheses;

    public static AudioInputManager Instance { private set; get; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            return;

        }

    }

    private void Start()
    {


        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            m_Recognitions.text = "Detected: " + text;
            OnSpeechResult?.Invoke(this, text);
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            m_Hypotheses.text = "Detecting: " + text;
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        m_DictationRecognizer.Start();
    }


    public event EventHandler<string> OnSpeechResult;




    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (m_DictationRecognizer.Status != SpeechSystemStatus.Running)
        {
            m_DictationRecognizer.Start();
        }
    }
}
