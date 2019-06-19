using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour
{
    private static BlockGameManager instance = null;

    public static BlockGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("BlockGameManager");
                instance = gameObject.AddComponent<BlockGameManager>();
            }
            return instance;
        }
    }

    private int point = 0;

    public int Point
    {
        set { point = value; }
        get { return point; }
        //set;
        //get;
    }

    private void Awake()
    {
        instance = this;
    }
}
