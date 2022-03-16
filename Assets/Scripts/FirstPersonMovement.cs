using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 3.5f;
    public int distanceOfRaycast = 5;

    private float gravity = 10f;
    private RaycastHit _hit;

    private CharacterController controller;

    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRaycast))
        {
            if (Input.GetButtonDown("Fire4") && _hit.transform.CompareTag("LoadingFromWeb"))
            {
                Debug.Log("aaaa");
                //int id = _hit.transform.gameObject.GetComponent<LoadingFromWeb>().id;
                //_hit.transform.gameObject.GetComponent<LoadingFromWeb>().Change("http://192.168.56.1/unity/images/image" + (id+10) + ".jpg");
            }
        }

        PlayerMovement();
    }
    
    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }
}