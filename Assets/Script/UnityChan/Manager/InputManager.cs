using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    // Delegate
    // Listener Pattern
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null; // ���׸��� �Ű����� Ÿ���� <in T>�� ��Ÿ�� �� �ִ�.

    bool _pressed = false;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }
    }
}