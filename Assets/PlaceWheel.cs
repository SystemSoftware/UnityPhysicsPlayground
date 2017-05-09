using UnityEngine;
using System.Collections;

public class PlaceWheel : MonoBehaviour {

    public float steerFactor = 0f;
    public float accelFactor = 0f;
    Transform wheel;
    WheelCollider wheelCollider;
    VehicleLogic owner;

    float rotationAt = 0f;
	// Use this for initialization
	void Start () {
        wheelCollider = GetComponent<WheelCollider>();
        owner = GetComponentInParent<VehicleLogic>();
        foreach (Transform t in transform)
            wheel = t;  //happens only once
	}


    public float t;

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        float at = wheelCollider.suspensionDistance + wheelCollider.radius;
        if (Physics.Raycast(new Ray(transform.position + transform.TransformVector(wheelCollider.center), -transform.up), out hit, at))
        {
            at = hit.distance + wheelCollider.radius;
        }

        t = wheelCollider.steerAngle = 25f * steerFactor * owner.steer;
        if (!((wheelCollider.steerAngle < 0f == accelFactor < 0f) ^ (steerFactor > 0f)))
            wheelCollider.steerAngle *= 0.75f;


        rotationAt += Time.deltaTime * wheelCollider.rpm / 60f * 360f * accelFactor;
        //rotationAt = Mathf.Repeat(rotationAt, 360f);

        wheel.localPosition = new Vector3(0, -(at - 2f * wheelCollider.radius), 0) + wheelCollider.center;
        wheel.localRotation = Quaternion.Euler(rotationAt, wheelCollider.steerAngle, -90);

        wheelCollider.motorTorque = -5f * owner.accel;
        if (Input.GetKey(KeyCode.LeftShift))
            wheelCollider.motorTorque *= 3f;
        wheelCollider.brakeTorque = 0f;

        this.GetComponent<LineRenderer>().SetPosition(0, wheel.position);
        this.GetComponent<LineRenderer>().SetPosition(1, wheelCollider.transform.position);
	    
	}
}
