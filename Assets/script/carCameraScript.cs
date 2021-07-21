using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCameraScript : MonoBehaviour

{

    private Vector3 Anchor;
    private Vector3 dragDis;
    private Vector3 Keep;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Anchor = Input.mousePosition;
            print(Anchor);
        }
        if (Input.GetMouseButton(0))
        {
            dragDis = Keep + Input.mousePosition - Anchor;
            if(dragDis.y  > 45.0f)
            {
                dragDis.y = 45.0f;
            }
            if (dragDis.y < -30.0f)
            {
                dragDis.y = -30.0f;
            }
            this.transform.localRotation = Quaternion.Euler(new Vector3(-1* 0.5f * dragDis.y, 0.5f * dragDis.x,0));
        }
        if (Input.GetMouseButtonUp(0))
        {
            Keep = dragDis;
        }
    }
}
