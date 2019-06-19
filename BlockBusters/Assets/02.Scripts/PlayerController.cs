using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform m_transform;

    public float m_speed = 5.0f;

    public GameObject m_ballPrefab;

    public Transform m_newBallTr;

    public bool isShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        //Generate the new ball when start
        GenNewBall();
    }

    void GenNewBall()
    {
        Vector3 initPos = m_transform.position + Vector3.up * 1.2f;
        Quaternion initRot = Quaternion.identity;
        GameObject newBall = (GameObject)Instantiate(m_ballPrefab, initPos, initRot);
        m_newBallTr = newBall.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left movement
        if(Input.GetKey(KeyCode.A))
        {
            m_transform.Translate(Vector3.left * m_speed * Time.deltaTime);
        }
        // Right movement
        else if (Input.GetKey(KeyCode.D))
        {
            m_transform.Translate(Vector3.right * m_speed * Time.deltaTime);
        }
        OnShoot();
    }

    private void OnCollisionEnter(Collision collision_)
    {
        if(collision_.gameObject.CompareTag("BALL"))
        {
            Vector3 reflect = collision_.transform.position - transform.position;
            float result = 0.0f;

            if(reflect.x > 0)
            {
                result = 1.0f;
            }
            else if(reflect.x < 0)
            {
                result = -1.0f;
            }

            collision_.rigidbody.AddForce(new Vector3(150.0f * result, 50.0f, 0.0f));

        }
    }

    // Shoot the ball
    public void OnShoot()
    {
        if(!isShoot)
        {
            m_newBallTr.position = m_transform.position + Vector3.up * 1.2f;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody ballRigidbody = m_newBallTr.GetComponent<Rigidbody>();
                if(ballRigidbody != null)
                {
                    isShoot = true;
                    ballRigidbody.AddForce(Vector3.up * 300.0f);
                }
            }
        }
    }
}
