using UnityEngine;
public class DisplayFollow : MonoBehaviour
{

    public Transform centerEyeAnchor;   // OVRCameraRig/CenterEyeAnchor
    public Transform seatPosition;      // Where the user should stay seated

    void LateUpdate()
    {
        // Only rotation should apply — cancel out position
        Vector3 headsetLocalOffset = centerEyeAnchor.localPosition;
        Vector3 cameraOffset = new Vector3(headsetLocalOffset.x, 0, headsetLocalOffset.z);

        // Move OVRCameraRig to keep camera at seat position
        transform.position = seatPosition.position - cameraOffset;
    }
}


