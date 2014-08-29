using UnityEngine;
using System.Collections;

public class CheckRuntimePlatform : MonoBehaviour {

    private GameObject ui_touchControls;

	// Use this for initialization
	void Start () {
        ui_touchControls = GameObject.Find("Canvas/UI_TouchControls");

        if (
                Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer ||   //Windows
                Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer ||   //Mac OSX
                Application.platform == RuntimePlatform.LinuxPlayer //Linux
           )
        {
            ui_touchControls.gameObject.SetActive(false);
            Debug.Log("Disabled Touch Controls");
        }
	}
}
