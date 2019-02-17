using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private static int N = 0;
    private static float CamHeight = 0.0f;
    private static float Unit = 0.0f;
    private static bool EnergyMode = false;
    private static float Dimensions = 0.0f;
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
    public static void setEnergy(bool energyMode)
    {
        EnergyMode = energyMode;
    }
    public static bool getEnergy()
    {
        return EnergyMode;
    }
    public static void setDimensions(float dimensions)
    {
        Dimensions = dimensions;
    }
    public static float getDimensions()
    {
        return Dimensions;
    }
}
