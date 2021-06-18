using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarBehaviour : MonoBehaviour
{

    CharacterNavigationController CarController;

    [Header("Sensors")]
    public float sensorLength = 3f;
    public Vector3 frontSensorPosition = new Vector3(0f, 0.2f, 0.5f);
    public float frontSideSensorPosition = 0.2f;
    public float frontSensorAngle = 30f;


    private void Start()
    {
        CarController = GameObject.Find("SportCar20").GetComponent<CharacterNavigationController>();
    }

    private void FixedUpdate()
    {
        Sensors();
    }

    private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position + frontSensorPosition;
        sensorStartPos += transform.forward * frontSensorPosition.z;
        sensorStartPos += transform.up * frontSensorPosition.y;

        CarController.movementSpeed = 5;

        //front center sensor
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            CarController.movementSpeed = 0;
            Debug.DrawLine(sensorStartPos, hit.point);
        }

        //front right sensor
        sensorStartPos.x += frontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            CarController.movementSpeed = 0;
            Debug.DrawLine(sensorStartPos, hit.point);
        }

        //front right angle sensor
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            CarController.movementSpeed = 0;
            Debug.DrawLine(sensorStartPos, hit.point);
        }

        //front left sensor
        sensorStartPos.x -= 2 * frontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            CarController.movementSpeed = 0;
            Debug.DrawLine(sensorStartPos, hit.point);
        }

        //front left angle sensor
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            CarController.movementSpeed = 0;
            Debug.DrawLine(sensorStartPos, hit.point);
        }

    }
}
