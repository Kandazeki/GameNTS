using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KillingCam : MonoBehaviour
{

    public GameObject ParticleEffect;
    private Vector2 touchPos;
    private RaycastHit hit;
    private Camera cam;

    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;

    private InputAction touchPhaseAction;
    void Start()
    {
        cam = GetComponent<Camera>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];
        touchPhaseAction = playerInput.actions["TouchPhase"];
    }

    
    void Update()
    {
        if (!touchPressAction.WasPerformedThisFrame())
        {
            return;
        }
        
        touchPos = touchPosAction.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.tag == "Ennemy")
            {
                var clone = Instantiate(ParticleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
            }
        }
        
    }
}
