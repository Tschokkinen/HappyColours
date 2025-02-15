using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class Timer : MonoBehaviour
{
    private const string LIBRARY_NAME = "CPP_expansions";

    [DllImport(LIBRARY_NAME)]
    private static extern IntPtr createTimer();

    [DllImport(LIBRARY_NAME)]
    private static extern double getPlayTime();

    [DllImport(LIBRARY_NAME)]
    private static extern void deleteTimer(IntPtr instance);

    IntPtr timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = createTimer();
    }

    public double StopTimer()
    {
        deleteTimer(timer);
        // double playTime = getPlayTime();
        //Debug.Log($"Play time: {Math.Round(playTime, 2)}");
        return Math.Round(getPlayTime(), 2);
    }
}
