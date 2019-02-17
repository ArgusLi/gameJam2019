using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private static int N;
    private static float CamHeight;
    private static float Unit;
    private static bool EnergyMode;
    private static float Dimensions;
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
