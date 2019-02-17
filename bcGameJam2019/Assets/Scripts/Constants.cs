using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private static int N;
    private static float CamHeight;
    private static float Unit;
	public Constants()
	{
	}
    public static void setN(int n)
    {
        N = n;
    }
    public static int getN()
    {
        return N;
    }
    public static void setCamHeight(float camHeight)
    {
        CamHeight = camHeight;
    }
    public static float getCamHeight()
    {
        return CamHeight;
    }
    public static void setUnit(float unit)
    {
        Unit = unit;
    }
    public static float getUnit()
    {
        return Unit;
    }
}
