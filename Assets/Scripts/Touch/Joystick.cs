using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour {

	public bool isPressed = false;

	// Update is called once per frame
	void Update () {
		isPressed = false;

		int count = Input.touchCount;

		for (int i = 0; i < count; i++)
		{
			Touch touch = Input.GetTouch(i);

            if (EventSystemManager.currentSystem.IsPointerOverEventSystemObject())
            {
                isPressed = true;
            }

			/*if (guiTexture.HitTest(touch.position))
			{
				isPressed = true;
			}*/
		}
	}
}
