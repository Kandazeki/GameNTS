using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ManagerCone : MonoBehaviour
{
    public ARRaycastManager RaycastManager;
    public TrackableType TypeToTrack = TrackableType.PlaneWithinBounds;
    public GameObject PrefabToInstantiate;
    public PlayerInput PlayerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;
    private bool Conalaready;
    public EnnemyManager vaguesetter;

    private int ConeLife;

    // Start is called before the first frame update
    void Start()
    {
        touchPressAction = PlayerInput.actions["TouchPress"];
        touchPosAction = PlayerInput.actions["TouchPos"];
        Conalaready = false;
        ConeLife = 100;
    }

    private void IsCone()
    {
        var touchPos = touchPosAction.ReadValue<Vector2>();
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(touchPos, hits, TypeToTrack);
        if (hits.Count > 0)
        {
            ARRaycastHit firstHit = hits[0];
            Vector3 vecteurcorrected = new Vector3(firstHit.pose.position.x, firstHit.pose.position.y+0.2f, firstHit.pose.position.z);
            Instantiate(PrefabToInstantiate, vecteurcorrected, firstHit.pose.rotation);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(touchPressAction.WasPerformedThisFrame() && !Conalaready)
        {
            IsCone();
            Conalaready =true;
        }
        if(ConeLife == 0)
        {
            Destroy(PrefabToInstantiate);
        }
    }

    public void Buttonvague()
    {
        if (vaguesetter.nmbenemy == 0)
        {
            vaguesetter.vague = true;
        }
        else
        {
            Debug.Log("All ennemy needs to be dead");
        }
 
    }
}
