using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class TrainController : MonoBehaviour
{
    public SplineContainer TrackSpline;
    public float Acceleration = 0f;
    public float MaxSpeed = 20f;
    public float speed = 0f;
    private float distance = 0f;
    private float splineTotalLength = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        splineTotalLength = TrackSpline.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        var newSpeed = speed + (Acceleration * dt);
        if (newSpeed > MaxSpeed)
            newSpeed = MaxSpeed;

        if (newSpeed < 0)
            newSpeed = 0;

        speed = newSpeed;

        var distanceIncrement = speed * dt;

        distance += distanceIncrement;

        if (distance > splineTotalLength)
            distance -= splineTotalLength;

        var distancePercentage = distance / splineTotalLength;

        TrackSpline.Evaluate(distancePercentage, out float3 position, out float3 tangent, out float3 upVector);

        transform.SetPositionAndRotation(position, Quaternion.LookRotation(tangent, upVector));

        GetComponent<AudioSource>().pitch = (speed / MaxSpeed) / 2;
    }
}
