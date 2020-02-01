using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public int m_PlayerNumber;

    public string LSX_KEY;
    public string LSY_KEY;
    public string RSX_KEY;
    public string RSY_KEY;
    public string LB_KEY;
    public string LT_KEY;
    public string RB_KEY;
    public string RT_KEY;
    public string UP_KEY;
    public string DOWN_KEY;
    public string LEFT_KEY;
    public string RIGHT_KEY;
    public string START_KEY;
    public string BACK_KEY;
    public string A_KEY;
    public string B_KEY;
    public string X_KEY;
    public string Y_KEY;

    private void Awake()
    {
        GetKeys();
    }

    private void GetKeys()
    {
        LSX_KEY = "X" + m_PlayerNumber + "Horizontal";
        LSY_KEY = "X" + m_PlayerNumber + "Vertical";
        RSX_KEY = "X" + m_PlayerNumber + "MouseX";
        RSY_KEY = "X" + m_PlayerNumber + "MouseY";
        LB_KEY = "X" + m_PlayerNumber + "LB";
        RB_KEY = "X" + m_PlayerNumber + "RB";
        LT_KEY = "X" + m_PlayerNumber + "LT";
        RT_KEY = "X" + m_PlayerNumber + "RT";
        UP_KEY = "X" + m_PlayerNumber + "Up";
        DOWN_KEY = "X" + m_PlayerNumber + "Down";
        LEFT_KEY = "X" + m_PlayerNumber + "Left";
        RIGHT_KEY = "X" + m_PlayerNumber + "Right";
        START_KEY = "X" + m_PlayerNumber + "Start";
        BACK_KEY = "X" + m_PlayerNumber + "Back";
        A_KEY = "X" + m_PlayerNumber + "A";
        B_KEY = "X" + m_PlayerNumber + "B";
        X_KEY = "X" + m_PlayerNumber + "X";
        Y_KEY = "X" + m_PlayerNumber + "Y";
    }


    public float GetLSX()
    {
        return Input.GetAxis(LSX_KEY);
    }
    public float GetLSY()
    {
        return Input.GetAxis(LSY_KEY);
    }

    public float GetRSX()
    {
        return Input.GetAxis(RSX_KEY);
    }
    public float GetRSY()
    {
        return Input.GetAxis(RSY_KEY);
    }

    public bool GetLB()
    {
        return Input.GetKey(LB_KEY);
    }
    public float GetLT()
    {
        return Input.GetAxis(LT_KEY);
    }

    public bool GetRB()
    {
        return Input.GetKey(RB_KEY);
    }
    public float GetRT()
    {
        return Input.GetAxis(RT_KEY);
    }

    public bool GetUp()
    {
        return Input.GetKey(UP_KEY);
    }

    public bool GetDown()
    {
        return Input.GetKey(DOWN_KEY);
    }

    public bool GetRight()
    {
        return Input.GetKey(RIGHT_KEY);
    }

    public bool GetLeft()
    {
        return Input.GetKey(LEFT_KEY);
    }

    public bool GetStart()
    {
        return Input.GetKey(START_KEY);
    }

    public bool GetBack()
    {
        return Input.GetKey(BACK_KEY);
    }

    public bool GetA()
    {
        return Input.GetKey(A_KEY);
    }

    public bool GetB()
    {
        return Input.GetKey(B_KEY);
    }

    public bool GetX()
    {
        return Input.GetKey(X_KEY);
    }

    public bool GetY()
    {
        return Input.GetKey(Y_KEY);
    }
}
