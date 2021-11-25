using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class KeywordScript : MonoBehaviour
{
    private string[] m_Keywords = {"blanco", "negro", "aleatorio"};
    public KeywordRecognizer m_Recognizer;

    void Start()
    {
      m_Recognizer = new KeywordRecognizer(m_Keywords);
      m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
    }

    void Update() 
    {
      float distanceToRecognizer = Vector3.Distance(GameObject.Find("Recognizer").transform.position, transform.position);
      if (distanceToRecognizer <= 40 && !m_Recognizer.IsRunning) {
        m_Recognizer.Start();
        Debug.Log("Start recognicer");
      } 
      else if (distanceToRecognizer > 40 && m_Recognizer.IsRunning) {
        m_Recognizer.Stop();
        Debug.Log("Stop recognicer");
      }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
      Renderer RecognizerRenderer = GameObject.Find("Recognizer").GetComponent<Renderer>();

      if (args.text == "blanco") {
        RecognizerRenderer.material.color = new Color( 1f, 1f, 1f, 1f );
      }
      else if (args.text == "negro") {
        RecognizerRenderer.material.color = new Color( 0f, 0f, 0f, 1f );
      }
      else if (args.text == "aleatorio") {
        RecognizerRenderer.material.color = UnityEngine.Random.ColorHSV();
      }
    }
}
