
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject prefab;
    public int parts = 12;
    
    [ContextMenu("Create")]
    public void Create()
    {
        var angle = 0;

        var angleSize = 360 / parts;
        
        for (int i = 0; i < parts; i++)
        {
            var go = Instantiate(prefab, transform);

            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = 
                new Vector3(go.transform.localEulerAngles.x, i * angleSize, go.transform.localEulerAngles.z);

        }
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
