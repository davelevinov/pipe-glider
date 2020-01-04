using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float followSpeed =  3f;
    private float _offsetY;
    
    // Start is called before the first frame update
    void Start()
    {
        _offsetY = transform.position.y - target.position.y;
        
        BallController.HitPlatform += OnHitPlatform;
        BallController.PassPlatform += OnPassPlatform;
    }

    private void OnDestroy()
    {
        BallController.HitPlatform -= OnHitPlatform;
        BallController.PassPlatform -= OnPassPlatform;
    }

    private void OnPassPlatform(Transform obj)
    {
        target = obj;
    }

    private void OnHitPlatform(Transform platform)
    {
        target = platform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        var targetPosY = target.position.y + _offsetY;

        var y = Mathf.Lerp(transform.position.y, targetPosY, Time.deltaTime * followSpeed);

        var pos = transform.position;

        pos.y = y;

        transform.position = pos;
    }
}
