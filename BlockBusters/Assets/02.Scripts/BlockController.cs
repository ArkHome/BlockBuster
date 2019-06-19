using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject m_itemPrefab;

    private void OnCollisionEnter(Collision collision_)
    {
        if(collision_.gameObject.CompareTag("BALL"))
        {
            Vector3 initPos = transform.position;
            Quaternion initRot = Quaternion.identity;

            if(m_itemPrefab != null)
            {
                GameObject newItem = (GameObject)Instantiate(m_itemPrefab, initPos, initRot);
                newItem.GetComponent<ItemController>().Point = Random.Range(50, 150);
            }

            Destroy(this.gameObject);
        }
    }
}
