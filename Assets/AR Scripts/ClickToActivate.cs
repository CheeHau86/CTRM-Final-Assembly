using UnityEngine;
using System.Collections;

public class ClickToActivate : MonoBehaviour {

    Vector3 offset, screenPoint;
    float RotSpeed = 5, ScaleX = 0, ScaleY = 0, ScaleZ = 0;

    void OnMouseDown() {

        //Destroy(gameObject);

        //gameObject.transform.localScale = new Vector3(2*L, 2*H, 2*W);

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.localScale.y / 2, Input.mousePosition.y));

    }


    //drag to move object
    void OnMouseDrag()
    {    
        if(Input.GetKey(KeyCode.LeftControl))
        {
            float RotX = Input.GetAxis("Mouse X") * -RotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, RotX);
        }

        else if (Input.GetKey(KeyCode.RightControl))
        {
            float RotX = Input.GetAxis("Mouse X") * -RotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, RotX);
        }

        else if (Input.GetKey(KeyCode.LeftShift))
        {
            ScaleX = Input.GetAxis("Mouse X");
            if (Input.GetKey(KeyCode.A))
            {
                ScaleY = Input.GetAxis("Mouse Y");
            }
            if (Input.GetKey(KeyCode.Z))
            {
                ScaleZ = Input.GetAxis("Mouse Y");
            }
            transform.localScale = new Vector3 (transform.localScale.x + ScaleX, transform.localScale.y + ScaleY, transform.localScale.z + ScaleZ);
        }

        else
	    {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            Vector3 ObjectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = new Vector3(ObjectPosition.x + offset.x, transform.localScale.y / 2, ObjectPosition.z + offset.z);
        }

     }
    
    /*
    //drag to rotate object
    void OnMouseDrag()
    {
        float RotX = Input.GetAxis("Mouse X") * -RotSpeed * Mathf.Deg2Rad;
        float RotY = Input.GetAxis("Mouse Y") * RotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, RotX);
        transform.RotateAround(Vector3.right, RotY);       

    }
    */
}
