using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZigSimTools;
using Quaternion = UnityEngine.Quaternion;
using UnityEngine.EventSystems;

public class ZigSimPlayer : MonoBehaviour
{
    private Quaternion targetRotation;
    public float speed = 0.0f;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
       ZigSimDataManager.Instance.StartReceiving(); 
       ZigSimDataManager.Instance.QuaternionCallBack += (ZigSimTools.Quaternion q)=>
       {
           var newQut = new Quaternion(0,0,-(float)q.y,(float)q.w);
           targetRotation = newQut;
       };
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = targetRotation;
       transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Obstacle")){
            speed=0.0f;
            ExecuteEvents.Execute<IReceiveMessage>(
			target: textObject,
			eventData: null,
			functor: (receiveTarget, y) => receiveTarget.OnReceive("Game Over"));

        }

        if(other.gameObject.CompareTag("Finish")){
            speed = 0.0f;
            ExecuteEvents.Execute<IReceiveMessage>(
			target: textObject,
			eventData: null,
			functor: (receiveTarget, y) => receiveTarget.OnReceive("Clear!"));

        }
    }
}
