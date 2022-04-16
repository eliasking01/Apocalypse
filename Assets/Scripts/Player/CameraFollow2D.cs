using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public float FollowSpeed = 2f;

    public float FollowSpeed2 = 2f;

    public float FollowSpeed3 = 2f;

    public Transform target;

    public Transform target2;

    public Transform target3;

    bool switched;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Crosshair").transform;
        target2 = GameObject.FindGameObjectWithTag("Player").transform;
        target3 = GameObject.FindGameObjectWithTag("Turret").transform;
    }

    void FixedUpdate()
    {
        if (TurretSwitch.switched)
        {
            target3 = GameObject.FindGameObjectWithTag("Turret").transform;
            switched = true;
        }
        else
        {
            switched = false;
        }

        Vector3 newPosition = target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);

        if (switched)
        {
            Vector3 newPosition3 = target3.position;
            newPosition3.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition3, FollowSpeed3 * Time.deltaTime);
        }
        else
        {
            Vector3 newPosition2 = target2.position;
            newPosition2.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition2, FollowSpeed2 * Time.deltaTime);
        }
    }
}