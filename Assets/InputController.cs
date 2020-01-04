using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector2 _lastPos;
    public float speedFactor = 1;

    // Start is called before the first frame update
    void Start()
    {
        _lastPos = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_lastPos == Vector2.zero)
            {
                _lastPos = Input.mousePosition;
            }
            else
            {
                var x = Input.mousePosition.x - _lastPos.x;

                _lastPos = Input.mousePosition;
                
                transform.Rotate(Vector3.up, x * speedFactor);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lastPos = Vector2.zero;
        }
    }
}
