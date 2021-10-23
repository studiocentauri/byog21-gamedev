using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent playerAI;

    public float vel;

    public float targetDistance = 0.5f;

    bool movingToTarget = false;

    Vector3 targetPos;

    bool movingToEvidence = false;

    void Awake()
    {
        playerAI = GetComponent<NavMeshAgent>();
        playerAI.speed = vel;
    }

    void Update()
    {
        if (movingToTarget)
        {
            if ((targetPos - transform.position).magnitude <= targetDistance * 1.5f)
            {
                if (movingToEvidence)
                {
                    GameObject.Find("ClickManager").GetComponent<ClickManager>().StartInspect();
                }
                else
                {
                    GameObject.Find("ClickManager").GetComponent<ClickManager>().StartDialogue();
                }
                movingToTarget = false;
            }
        }
    }

    public void MovePlayer(Vector3 point)
    {
        Vector3 pos = transform.position;
        pos.x = point.x;
        pos.z = point.y;
        playerAI.SetDestination(point);
    }

    public void MoveToTarget(Vector3 target, bool item = false)
    {
        movingToTarget = true;
        movingToEvidence = item;
        targetPos = target;
        Vector3 dir = target - transform.position;
        dir.Normalize();
        Vector3 newTarget = target - dir * targetDistance;
        MovePlayer(newTarget);
    }
}
