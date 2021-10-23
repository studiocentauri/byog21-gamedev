using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_camera : MonoBehaviour
{
    public bool zooming = false;
    public float zoomSpeed = 5f;
    public Camera cam;

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            zooming = true;
            zoomSpeed = 30f;
        }

        if (zooming)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            zoomDistance += zoomSpeed * Input.mouseScrollDelta.y * Time.deltaTime;
            cam.transform.Translate(ray.direction * zoomDistance, Space.World);
        }

        //restrict distance between player.pos and fps_cam position
        //zoom with scroll
    }
}
