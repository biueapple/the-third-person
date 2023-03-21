using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Camera cam;
    public Movement follow;

    [Header("�ִ�Ÿ��� �ּҰŸ�")]
    public float maxDistance;
    public float minDistance;
    [Header("���� �Ÿ�")]
    public float distance;
    [Header("�ܵ�������")]
    public bool solo;

    public float cosY;
    public float sinY;
    public float cosX;
    public float sinX;

    void Start()
    {
        
    }


    void Update()
    {
        distance = Vector3.Distance(cam.transform.position, follow.transform.position);
        if(solo)
        {

        }
        else
        {
            SphericalCoordinate();
        }
    }

    public void SphericalCoordinate()         
    {
        cosY = Mathf.Cos(follow.angle.y * Mathf.Deg2Rad);
        sinY = Mathf.Sin(follow.angle.y * Mathf.Deg2Rad);

        cosX = Mathf.Cos((follow.angle.x + 180)  * Mathf.Deg2Rad);
        sinX = Mathf.Sin((follow.angle.x + 180) * Mathf.Deg2Rad);

        cam.transform.position = new Vector3(sinX, sinY, cosX * cosY) * maxDistance;

        cam.transform.eulerAngles = new Vector3(follow.angle.y, follow.angle.x, cam.transform.eulerAngles.z);
    }

}
