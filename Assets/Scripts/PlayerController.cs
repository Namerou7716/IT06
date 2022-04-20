using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Player Info
    public float speed = 0;

    private Rigidbody rb;

    private float movementX,movementY;

    //others
    private int collect_count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        collect_count=0;
        rb = GetComponent<Rigidbody>(); 

        //Set anything
        SetOnText();
        winTextObject.SetActive(false);

    }

    private void OnMove(InputValue movementValue){
        Vector2 _movementVector = movementValue.Get<Vector2>();

        movementX = _movementVector.x;
        movementY = _movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector3 _movement = new Vector3(movementX,0.0f,movementY);
       rb.AddForce(_movement*speed); 

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("CollectableItem"))
        {
            other.gameObject.SetActive(false);
            Object.Destroy(other.gameObject);
            //UI
            collect_count++;
            SetOnText();
        }
    }

    void SetOnText()
    {
        countText.text = "Count" + collect_count.ToString();

        if(collect_count>=12){
            winTextObject.SetActive(true);
        }
    }

}
