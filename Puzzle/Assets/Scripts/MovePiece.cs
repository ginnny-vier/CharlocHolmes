using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject selectedObject;
    Vector3 offset;
    private Rigidbody2D rb;

    public string pieceStatus = "";

    void Start()
    {

    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }

        void OnTriggerEnter2D(Collider2D other)
        {   
            if (other.gameObject.name == gameObject.name+1)

                {
                    transform.position = other.gameObject.transform.position;
                    pieceStatus = "Locked";
                    Debug.Log(pieceStatus);

                }
        }
    }
}
