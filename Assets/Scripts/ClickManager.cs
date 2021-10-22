using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject player;

    public float maxDistance = 10000.0f;

    int layerMask;

    public string[] ignoreLayer = { "Wall", "Player" };

    void Awake()
    {
        layerMask = LayerMask.GetMask(ignoreLayer);
        layerMask = ~layerMask;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mRay, out hit, maxDistance, layerMask))
            {
                Debug.Log(hit.collider.gameObject.name + "  " + hit.point);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                if (hit.collider.gameObject.tag == "Ground")
                {
                    MovePlayer(hit.point);
                }
                else
                {
                    // Talk to NPC or Inspect Evidence
                }
            }
        }
    }

    void MovePlayer(Vector3 point)
    {
        Vector3 pos = player.transform.position;
        pos.x = point.x;
        pos.z = point.z;
        player.transform.position = pos;
    }
}
