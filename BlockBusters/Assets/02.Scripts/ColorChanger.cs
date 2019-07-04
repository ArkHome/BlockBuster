using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChanger : MonoBehaviour
{
    [SerializeField]
     Image _currentImage;

    public void OnPointerOn()
    {

        _currentImage.color = new Color(0.5f, 0.5f, 0.5f);
    }



}
