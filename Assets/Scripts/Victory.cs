using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    [SerializeField]
    private string _sentence;
    private void Start()
    {
        EventAggregattor.Instance.Finish += OnFinish;
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void OnFinish()
    {
        _textMesh.enabled = true;
        StartCoroutine(TypeSentence(_sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        _textMesh.text = "";
        foreach (char symbol in sentence.ToCharArray())
        {
            _textMesh.text += symbol;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnDestroy()
    {
        EventAggregattor.Instance.Finish -= OnFinish;
    }
}
