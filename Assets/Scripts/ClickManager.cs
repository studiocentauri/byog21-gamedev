using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject player;

    public float maxDistance = 10000.0f;

    int layerMask;

    public string[] ignoreLayer = { "Wall", "Player" };

    bool canClick = true;

    GameObject dialogueNPC = null;

    GameObject clueObject = null;

    public mouse_cursor cursorObject;

    public clue_info_highlight infoObject;

    void Awake()
    {
        layerMask = LayerMask.GetMask(ignoreLayer);
        layerMask = ~layerMask;
    }

    void FixedUpdate()
    {
        if (canClick)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mRay, out hit, maxDistance, layerMask))
            {
                if (hit.collider.gameObject.tag == "Witness")
                {
                    Debug.Log("Click to talk to NPC");
                }
                if (hit.transform.gameObject.tag == "clue")
                {
                    cursorObject.cursor_on_clue();
                }
                else
                {
                    cursorObject.change_cursor_to_default();
                }
            }
            else
            {
                cursorObject.change_cursor_to_default();
            }
        }
        else
        {
            cursorObject.change_cursor_to_default();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mRay, out hit, maxDistance, layerMask))
            {
                Debug.Log(hit.collider.gameObject.name + "  " + hit.point);
                if (hit.collider.gameObject.tag == "Ground")
                {
                    player.GetComponent<PlayerMovement>().MovePlayer(hit.point);
                }
                else if (hit.collider.gameObject.tag == "Witness")
                {
                    player.GetComponent<PlayerMovement>().MoveToTarget(hit.point);
                    canClick = false;
                    dialogueNPC = hit.collider.gameObject;
                }
                else if (hit.collider.gameObject.tag == "clue")
                {
                    canClick = false;
                    clueObject = hit.collider.transform.gameObject;
                    Vector3 point = hit.point;
                    point.y = 0;
                    player.GetComponent<PlayerMovement>().MoveToTarget(point, true);
                }
            }
        }
    }

    public void StopClick()
    {
        canClick = false;
        player.GetComponent<PlayerMovement>().MovePlayer(player.transform.position);
    }

    public void ResetClick()
    {
        canClick = true;
    }

    public void StartDialogue()
    {
        dialogueNPC.GetComponentInParent<Dialogue>().InitiateDialogue();
    }

    public void StartInspect()
    {
        infoObject.clue_found(clueObject);
    }

}
