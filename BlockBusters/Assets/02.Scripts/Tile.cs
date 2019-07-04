using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    [SerializeField]
    Image _tileImage;

    [SerializeField]
    Sprite _colorImage;

    [SerializeField]
    Sprite _emptyImage;
    public void OnDragTile()
    {
        if (TileManager.Instance.IsDragOn && TileManager.Instance.CurrentPicker != null)
        {
            if(TileManager.Instance.CurrentPicker.IsEraser ==false)
                _tileImage.sprite = _colorImage;
            else
                _tileImage.sprite = _emptyImage;

            _tileImage.color = TileManager.Instance.TileColor;
        }
    }
    public void OnClickTile()
    {
        if (TileManager.Instance.CurrentPicker !=null)
        {
            if (TileManager.Instance.CurrentPicker.IsEraser == false)
                _tileImage.sprite = _colorImage;
            else
                _tileImage.sprite = _emptyImage;
            _tileImage.color = TileManager.Instance.TileColor;
        }
    }
    public void OnDragEnd()
    {
        TileManager.Instance.IsDragOn = false;
    }

    public void OnDragStart()
    {
        TileManager.Instance.IsDragOn = true;
    }
}
