using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public Vector3 currentPos;
    public Vector3 destination; 
    public int duration = 1;
    public int distance = 800; 
    void Start()
    {
        currentPos = gameObject.transform.position;
        destination = currentPos; 
    }


    public void UpdateDestination ()
    {
        currentPos = gameObject.transform.position;
        destination.x += distance;
        StartCoroutine(MoveCamera()); 
    }
   /* private void moveToDestination()
    {
        float step = 0; 
        if (currentPos.x < destination.x)
        {
            currentPos.x += step;
            transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        }
        if (currentPos.x > destination.x)
        {
        
            currentPos.x += step;
            transform.position = Vector3.MoveTowards(transform.position, destination, -speed);
        }
    } */

    IEnumerator MoveCamera()
    {
        float deltaTime = 0; 

        while(deltaTime < duration)
        {
            float xPos = Mathf.Lerp(currentPos.x, destination.x, deltaTime/duration);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            deltaTime += Time.deltaTime;
            print("deltaTime: " + deltaTime);
            yield return null;
        }

      
        yield return null;
        StopCoroutine(MoveCamera());
        /*while (currentPos.x < destination.x)
        {
            moveToDestination();
            yield return null; 
        }
        ;*/
    }
}
