using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    public GameObject Cat;

    public float timer;

    public int newtarget;

    public float speed;


    public Vector3 Target;

    private void Start()
    {
        timer = newtarget;
    }

    private void Update()
    {

        timer += Time.deltaTime;

        if (timer >= newtarget)
        {
            newTarget();
            timer = 0;
        }

        if(transform.position.x - Target.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        gameObject.transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);

    }

    private void newTarget()
    {
        float myX = gameObject.transform.position.x;
        float myY = gameObject.transform.position.y;

        float xPos = Random.Range(myX - 6, myX + 6);
        float yPos = Random.Range(myY - 6, myY + 6);

        Target = new Vector3(xPos, yPos, gameObject.transform.position.z);
    }
}
