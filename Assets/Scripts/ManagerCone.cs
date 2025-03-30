using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

    public int ConeLife;

    [SerializeField]private TMP_Text life;

    public bool wasclicked;

    public int nmbupdate;

    // Start is called before the first frame update
    void Start()
    {
        touchPressAction = PlayerInput.actions["TouchPress"];
        touchPosAction = PlayerInput.actions["TouchPos"];
        Conalaready = false;
        ConeLife = 100;
        nmbupdate = 0;
        wasclicked =false;
    }

    public void IsCone()
    {
        var touchPos = touchPosAction.ReadValue<Vector2>();
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(touchPos, hits, TypeToTrack);
        if (hits.Count > 0)
        {
            ARRaycastHit firstHit = hits[0];
            Vector3 vecteurcorrected = new Vector3(firstHit.pose.position.x, firstHit.pose.position.y+0.2f, firstHit.pose.position.z);
            Instantiate(PrefabToInstantiate, vecteurcorrected, Quaternion.Euler(270f,0f,0f));
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
        nmbupdate += 1;
        if (nmbupdate == 1000 && wasclicked && vaguesetter.enemy != 0)
        {
            ConeLife = ConeLife - 5 <= 0 ? 1 : ConeLife - 5;
            life.text = "Cone Life : "+ ConeLife;
            nmbupdate = 0;
        }
        if (ConeLife == 1)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log(ConeLife);
        
    }

    public void Buttonvague()
    {
        vaguesetter.vague = true;
        wasclicked =true;
    }
}
