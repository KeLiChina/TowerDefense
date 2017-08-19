using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    private bool doCameraMove = true;
    private Vector3 posTemp = Vector3.zero;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            doCameraMove = !doCameraMove;
        if (!doCameraMove)
            return;
        ChangeCamPos();
    }
    private void ChangeCamPos()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        posTemp = transform.position;
        posTemp.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        posTemp.y = Mathf.Clamp(posTemp.y, minY, maxY);
        transform.position = posTemp;
    }
}
