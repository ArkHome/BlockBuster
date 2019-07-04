using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ColorPickerManager : MonoBehaviour
{

    public bool loadFromScene = true;
    public InGameColorPicker[] colorPicker;

    private List<InGameColorPicker> mColorPickerList;

    void Start()
    {
        if (loadFromScene)
        {
            colorPicker = GameObject.FindObjectsOfType<InGameColorPicker>();
        }
        mColorPickerList = new List<InGameColorPicker>();
        mColorPickerList.AddRange(colorPicker);

        mColorPickerList = mColorPickerList.OrderBy(item => item.drawOrder).ToList();
        mColorPickerList.Reverse();
        mColorPickerList.CopyTo(colorPicker);

        foreach (var elem in mColorPickerList)
        {
            elem.useExternalDrawer = true;
        }
    }

    void OnGUI()
    {
        foreach (var elem in mColorPickerList)
        {
            elem._DrawGUI();
        }
    }
}
