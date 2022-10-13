using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airPatrol : MonoBehaviour
{
    public Transform point1;
    public int Angle = 180;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public float speed = 2f;
    public float waitTime = 1f;
    bool canGo = true;



    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y , transform.position.z);
    }

   
    void Update() 
    {
        if (canGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        }
        if (transform.position == point1.position)
        {
            Transform t = point1;
            point1 = point2;
            point2 = point3;
            point3 = point4;
            point4 = t;
            canGo = false;
            StartCoroutine(Waiting());
            Angle = Angle + 180 % 360;
            transform.eulerAngles = new Vector3(0, Angle, 0);
        }
    }
    IEnumerator Waiting() 
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;
    
    
    }
}
