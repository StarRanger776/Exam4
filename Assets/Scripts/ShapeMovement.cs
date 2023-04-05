using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Shape")
                {
                    hit.collider.gameObject.transform.position = new Vector3(hit.point.x, 2, hit.point.z);
                }
            }
        }

        /*
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        gameObject.transform.position = worldPosition;
        */
    }
    
}
