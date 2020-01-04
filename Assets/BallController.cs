using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static event Action<Transform> HitPlatform = delegate(Transform transform1) {  };
    public static event Action<Transform> PassPlatform = delegate(Transform transform1) {  }; 
    public static event Action HitGoal = delegate {  };
    public static event Action<BallController> KillBall = delegate {  };
    
    public Rigidbody rigidbody;

    [SerializeField]
    private float upForce = 5;

    private bool _collisionActive;
    private bool _didComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        _didComplete = false;
        _collisionActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_collisionActive)
            return;

        if (other.gameObject.CompareTag("Kill"))
        {
            KillBall.Invoke(this);
            //TODO: send kill event
        }else if (other.gameObject.CompareTag("Goal"))
        {
            if (!_didComplete)
            {
                _didComplete = true;
                Invoke(nameof(NotifyLevelComplete), 1.5f);
            }
        }

        _collisionActive = true;
        rigidbody.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        
        Invoke(nameof(ResetCollision), .2f);
        
        HitPlatform.Invoke(other.transform);
    }

    private void NotifyLevelComplete()
    {
        HitGoal.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        PassPlatform.Invoke(transform);
    }

    private void ResetCollision()
    {
        _collisionActive = false;
    }
}
