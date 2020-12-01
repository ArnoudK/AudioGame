using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class AudioInputManager : MonoBehaviour
{



    private DictationRecognizer m_DictationRecognizer;


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

    public event EventHandler<string> OnSpeechResult;
    public event EventHandler<string> OnSpeechHypothesis;

#if UNITY_EDITOR

    public void InvokeOnSPeechResult(string e)
    {
        OnSpeechResult?.Invoke(this, e);
    }
#endif
    private void Start()
    {
        m_DictationRecognizer = new DictationRecognizer();
        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {

            OnSpeechResult?.Invoke(this, text);
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            OnSpeechHypothesis?.Invoke(this, text);
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





    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


}




