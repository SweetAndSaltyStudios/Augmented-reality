using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    private GameObject webPlane;
    private GameObject cameraParent;

    private void Awake()
    {
        webPlane = transform.GetChild(0).gameObject;
        cameraParent = new GameObject("CameraParent");
        cameraParent.transform.SetParent(transform);
        cameraParent.transform.Rotate(Vector3.right, 90);
        Input.gyro.enabled = true;

        WebCamTexture webCamTexture = new WebCamTexture();
        webPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }

    private void Update()
    {
        Quaternion rotationFix = new Quaternion(
            Input.gyro.attitude.x,
            -Input.gyro.attitude.y,
            -Input.gyro.attitude.z,
            -Input.gyro.attitude.w
            );
        transform.localRotation = rotationFix;
    }
}
