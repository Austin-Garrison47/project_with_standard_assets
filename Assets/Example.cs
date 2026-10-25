using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score:" + score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject theOtherObject;
        theOtherObject = hit.collider.gameObject;
        if (theOtherObject.name == "box")
        {
            Destroy(theOtherObject);
            score++;
            Debug.Log("New Score:" + score);

        }
    }
}
