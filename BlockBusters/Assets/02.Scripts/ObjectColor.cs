﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    void OnSetColor(Color color)
    {
        Material mt = new Material(GetComponent<Renderer>().sharedMaterial);
        mt.color = color;
        GetComponent<Renderer>().material = mt;
    }

    void OnGetColor(InGameColorPicker picker)
    {
        picker.NotifyColor(GetComponent<Renderer>().material.color);
    }

    public void test()
    {
        Debug.Log("dddddd");
    }
}
