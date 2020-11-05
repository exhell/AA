using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 250;
    [SerializeField] private Transform playerTrans;
    private float xRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseCamRot();
    }



    void MouseCamRot()
    {
        xRot -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, -90, 90);
        playerTrans.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
