using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI Control

public class PointTextController : MonoBehaviour
{
    private Text myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();

        MyTextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        MyTextUpdate();
    }

    private void MyTextUpdate()
    {
        if (myText.text != null)
        {
            myText.text = BlockGameManager.Instance.Point.ToString();
        }
    }
}
