using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mouse3D : MonoBehaviour {

    public static Mouse3D Instance { get; private set; }

    [SerializeField] private LayerMask mouseColliderLayerMask = new LayerMask();
    
    [SerializeField] private LayerMask ignoreLayerMask;

    int UILayer;

    private void Awake() {
        Instance = this;
    }
    
    private void Start()
    {
        UILayer = LayerMask.NameToLayer("IgnoreLayer");
    }

    /*
    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask & ignoreLayerMask)) {
            transform.position = raycastHit.point;
        }
        //print(IsPointerOverUIElement() ? "Over UI" : "Not over UI");
    }
    */

    public static Vector3 GetMouseWorldPosition() => Instance.GetMouseWorldPosition_Instance();

    private Vector3 GetMouseWorldPosition_Instance() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // gets the layermask index of the PanelForGrid layermask/layer
        //ignoreLayerMask = LayerMask.NameToLayer("IgnoreLayer");
        
        // Sets the Gameobject Canvas UIs layer to the index of the UI layer
        //canvasUI.layer = ignoreLayerMask;
        
        /*if (Physics.Raycast(ray, out RaycastHit raycastHit2, 999f,  ignoreLayerMask)){
            return Vector3.zero;
        }*/
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f,  mouseColliderLayerMask) && !IsPointerOverUIElement()){
            return raycastHit.point;
        }
        else {
            //Debug.Log("Derp");
            return Vector3.zero;
        }
    }
    
    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
    
    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }
 
 
    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

}
