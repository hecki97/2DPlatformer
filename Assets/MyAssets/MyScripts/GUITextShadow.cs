using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUITextShadow : MonoBehaviour {

    public Text guiText;
    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = guiText.text;
    }
}
