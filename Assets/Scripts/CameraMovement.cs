using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum CAM_STATE
    {
        FOLLOW,
        DIALOGUE,
        INSPECT,
        TRANSITION,
    };

    public CAM_STATE state = CAM_STATE.FOLLOW;

    public GameObject player;

    public Vector3 posOffset;

    public float moveFactor;

    public float angles = 0.0f;

    public float mouseSensitivity = 100f;

    public int x;

    public int maxZoom = 2;

    private GameObject lookObject;

    public Vector3 dialogueOffset;

    public Vector2 dialogueAR;

    Vector3 backupPos;

    Quaternion backupRot;


    void Start()
    {
        angles = 0.0f;
        x = 0;
    }

    void LateUpdate()
    {
        switch (state)
        {
            case CAM_STATE.FOLLOW:
                FollowPlayer();
                break;
            case CAM_STATE.DIALOGUE:
                FollowlookObject();
                break;
            case CAM_STATE.INSPECT:
                InspectItem();
                break;
            case CAM_STATE.TRANSITION:
                ResetCamera();
                break;
        }
    }

    void FollowPlayer()
    {
        Vector3 originPos = player.transform.position + posOffset;
        Vector3 offset = originPos - player.transform.position;

        //Vector3 offset = transform.position - player.transform.position;
        if (Input.GetMouseButton(1))
        {
            angles += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            if (angles >= 360.0f)
            {
                angles -= 360.0f;
            }
            if (angles <= -360.0f)
            {
                angles += 360.0f;
            }
        }
        offset = Quaternion.Euler(0.0f, angles, 0.0f) * offset;

        Vector3 newPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, moveFactor);

        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        Vector3 desiredForward = Vector3.Lerp(transform.forward, direction, moveFactor);

        Vector3 up = Vector3.up;
        Vector3 forward = desiredForward;
        Vector3 right = Vector3.Cross(up, forward);
        up = Vector3.Cross(forward, right);

        if (Input.GetKeyDown(KeyCode.Q) || Input.mouseScrollDelta.y > 0)
        {
            x++;
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.mouseScrollDelta.y < 0)
        {
            x--;
        }
        x = Mathf.Clamp(x, -maxZoom, maxZoom);

        Vector3 desiredPos = player.transform.position +
         forward * (posOffset.z + x) + up * posOffset.y + right * posOffset.x;

        transform.position = Vector3.Lerp(transform.position, desiredPos, moveFactor);
        transform.forward = Vector3.Lerp(transform.forward, (player.transform.position - transform.position).normalized, moveFactor);
    }

    public void StartDialogue(GameObject target)
    {
        lookObject = target;
        state = CAM_STATE.DIALOGUE;
        backupPos = transform.position;
        backupRot = transform.rotation;
    }

    public void EndDialogue()
    {
        state = CAM_STATE.TRANSITION;
    }

    void FollowlookObject()
    {
        FollowTarget();
        SetupAR();
    }

    void FollowTarget()
    {
        Vector3 direction = lookObject.transform.position - player.transform.position;
        direction.Normalize();
        Vector3 desiredForward = Vector3.Lerp(transform.forward, direction, moveFactor);

        Vector3 up = Vector3.up;
        Vector3 forward = desiredForward;
        Vector3 right = Vector3.Cross(up, forward);
        up = Vector3.Cross(forward, right);

        Vector3 desiredPos = player.transform.position +
         forward * dialogueOffset.z + up * dialogueOffset.y + right * dialogueOffset.x;

        transform.position = Vector3.Lerp(transform.position, desiredPos, moveFactor / 2.0f);
        transform.forward = Vector3.Lerp(transform.forward, (lookObject.transform.position - transform.position).normalized, moveFactor);
    }

    void SetupAR()
    {
        Vector2 currentRes = new Vector2(Screen.width, Screen.height);
        Vector2 targetRes = currentRes;
        if ((dialogueAR.x / dialogueAR.y) > (currentRes.x / currentRes.y))
        {
            targetRes.y = (targetRes.x / dialogueAR.x) * dialogueAR.y;
        }
        else
        {
            targetRes.x = (targetRes.y / dialogueAR.y) * dialogueAR.x;
        }

        Vector2 offset = ((currentRes - targetRes) / currentRes) / 2.0f;
        offset = Vector2.Lerp(new Vector2(Camera.main.rect.x, Camera.main.rect.y), offset, moveFactor);

        targetRes /= currentRes;
        targetRes = Vector2.Lerp(new Vector2(Camera.main.rect.width, Camera.main.rect.height), targetRes, moveFactor);

        Camera.main.rect = new Rect(offset.x, offset.y, targetRes.x, targetRes.y);
    }

    void ResetCamera()
    {
        transform.position = Vector3.Lerp(transform.position, backupPos, moveFactor);
        transform.rotation = Quaternion.Lerp(transform.rotation, backupRot, moveFactor);
        Camera.main.rect = new Rect(Mathf.Lerp(Camera.main.rect.x, 0.0f, moveFactor),
                                    Mathf.Lerp(Camera.main.rect.y, 0.0f, moveFactor),
                                    Mathf.Lerp(Camera.main.rect.width, 1.0f, moveFactor),
                                    Mathf.Lerp(Camera.main.rect.height, 1.0f, moveFactor));
        if ((transform.position - backupPos).magnitude <= 0.01f)
        {
            state = CAM_STATE.FOLLOW;
        }
    }

    public void StartInspect(GameObject target)
    {
        lookObject = target;
        state = CAM_STATE.INSPECT;
        backupPos = transform.position;
        backupRot = transform.rotation;
    }

    public void EndInspect()
    {
        state = CAM_STATE.TRANSITION;
    }

    void InspectItem()
    {
        Vector3 desiredPos = player.transform.position;
        desiredPos.y = lookObject.transform.position.y;
        Vector3 desiredForward = lookObject.transform.position - desiredPos;

        if (Input.GetKeyDown(KeyCode.Q) || Input.mouseScrollDelta.y > 0)
        {
            x++;
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.mouseScrollDelta.y < 0)
        {
            x--;
        }
        if (Input.GetButtonDown("Submit"))
        {
            x++;
        }
        x = Mathf.Clamp(x, -maxZoom, maxZoom);

        desiredPos += desiredForward * (x / 2.0f);

        transform.position = Vector3.Lerp(transform.position, desiredPos, moveFactor / 2.0f);
        transform.forward = Vector3.Lerp(transform.forward, desiredForward, moveFactor / 2.0f);
    }
}
