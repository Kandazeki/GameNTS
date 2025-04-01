using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class KillingCam2 : MonoBehaviour
{
    [SerializeField]private TMP_Text countleft;
    public GameObject ParticleEffect;
    private Vector2 touchPos;
    private RaycastHit hit;
    private Camera cam;
    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;
    public EnnemyManager enemisbeg;
    public static bool audio;

    public int left;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];
        left = 0;
        audio = false;
    }

    // Update is called once per frame
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
                    left += 1;
                    countleft.text = "Nombre d'ennemi tue : " + left;
                    audio = true;
                }
        }
        
    }
}
