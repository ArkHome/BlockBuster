using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorPickerObject : MonoBehaviour
{
    [SerializeField]
    GameObject _selectObject;

    [SerializeField]
    Image _objectImage;

    [SerializeField]
    bool _isEraser;

    bool _isSelected = false;

    public bool IsEraser { get => _isEraser; set => _isEraser = value; }

    public void OnClickColorObj()
    {
        if (TileManager.Instance.CurrentPicker != null)
        {
            TileManager.Instance.CurrentPicker.DeSelectAction();
        }

            SelectAction();
        
    }

    public void SelectAction()
    {
        TileManager.Instance.CurrentPicker = this;
        TileManager.Instance.TileColor = _objectImage.color;
        _isSelected = true;
        _selectObject.SetActive(true);
    }

    public void DeSelectAction()
    {
        _selectObject.SetActive(false);
    }

}
