using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour
{
  private DictationRecognizer m_DictationRecognizer;
  private bool IsRunning = false;

  void Start()
  {
    m_DictationRecognizer = new DictationRecognizer();
    GameObject.Find("Dictation").GetComponent<TextMesh>().text = "";

    m_DictationRecognizer.DictationResult += (text, confidence) =>
    {
      GameObject.Find("Dictation").GetComponent<TextMesh>().text = text;
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
  }

  void Update() {
    float distanceToDictation = Vector3.Distance(GameObject.Find("Dictation").transform.position, transform.position);
    if (distanceToDictation <= 40 && !IsRunning) {
      m_DictationRecognizer.Start();
      Debug.Log("Start dictation");
      IsRunning = true;
    } 
    else if (distanceToDictation > 40 && IsRunning) {
      m_DictationRecognizer.Stop();
      IsRunning = false;
      GameObject.Find("Dictation").GetComponent<TextMesh>().text = "";
      Debug.Log("Stop dictation");
    }
  }
}
