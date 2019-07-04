using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
public class TileManager : MonoBehaviour
{
    private static TileManager instance = null;
    [SerializeField]
    Color _tileColor;

    public class ColorItem
    {
        public int r;
        public int g;
        public int b;
    }
    public static TileManager Instance 
    {
        get
        {
            return instance;
        }
    }
    [System.Serializable]
   public class Grid
    {
        public int boardXsize;
        public int boardYsize;

        public int cellXsize;
        public int cellYsize;
    }

    [SerializeField]
    Grid _currentBoardInfo;

    [SerializeField]
    GameObject parentObject;

    bool _isDragOn = false;
    ColorPickerObject _currentPicker;

    List<ColorItem> _tileColorList = new List<ColorItem>();
    public Color TileColor
    {
        get
        {
            return _tileColor;
        }
        set
        {
            _tileColor = value;
        }
    }

    public bool IsDragOn { get => _isDragOn; set => _isDragOn = value; }
    public ColorPickerObject CurrentPicker { get => _currentPicker; set => _currentPicker = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        for (int i =0; i < _currentBoardInfo.boardXsize ; i++)
        {
            for (int j = 0; j < _currentBoardInfo.boardYsize; j++)
            {
                GameObject obj = Instantiate(Resources.Load("Prefabs/Tile") as GameObject, parentObject.transform);
             //   obj.GetComponent<RectTransform>().sizeDelta = new Vector2(_currentBoardInfo.cellXsize, _currentBoardInfo.cellYsize);
                obj.GetComponent<RectTransform>().position = new Vector3(obj.transform.position.x + _currentBoardInfo.cellXsize * i, obj.transform.position.y+ _currentBoardInfo.cellYsize * j, obj.transform.position.z);
                Color imageColor = obj.GetComponent<Image>().color;
                _tileColorList.Add(new ColorItem {r=(int)imageColor.r,g= (int)imageColor.g,b= (int)imageColor.b });
            }//  obj.transform.SetParent(parentObject.transform);
        }
    } 

    public void SaveToJson()
    {
        JsonData jsonData = JsonMapper.ToJson(_tileColorList);
        File.WriteAllText(Application.dataPath + "/ItemData.json", jsonData.ToString());
      
    }
}
