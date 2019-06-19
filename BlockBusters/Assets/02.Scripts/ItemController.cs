using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private float m_rotSpeed = 180.0f;
    private Transform m_transform;
    //private Color m_color;
    private int point = 0;
    public int Point
    {
        set { point = value; }
        get { return point; }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 200.0f);
        this.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        m_transform.Rotate(Vector3.forward * m_rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other_)
    {
        if(other_.gameObject.CompareTag("Player"))
        {
            BlockGameManager.Instance.Point += point;
            Destroy(this.gameObject);
        }
    }
}
