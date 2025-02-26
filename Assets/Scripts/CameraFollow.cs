using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public Vector3 PositionOffset;
    public Vector3 LookAtOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        var newCameraPosition = ObjectToFollow.transform.TransformPoint(PositionOffset);

        //transform.rotation = ObjectToFollow.transform.rotation;
        
        transform.position = newCameraPosition;
        transform.LookAt(ObjectToFollow.transform.position + LookAtOffset);
    }
}
