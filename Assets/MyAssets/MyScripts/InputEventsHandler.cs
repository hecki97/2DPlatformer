using UnityEngine;
using System.Collections;

public class InputEventsHandler : MonoBehaviour {

    public delegate void InputEventHandler();
    public static event InputEventHandler OnInputJump;
    public static event InputEventHandler OnInputAttack;

    public static void InputJump()
    {
        if (OnInputJump != null)
            OnInputJump();
    }

    public static void InputAttack()
    {
        if (OnInputAttack != null)
            OnInputAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            InputJump();

        if (Input.GetButtonDown("Fire1"))
            InputAttack();
    }
}
