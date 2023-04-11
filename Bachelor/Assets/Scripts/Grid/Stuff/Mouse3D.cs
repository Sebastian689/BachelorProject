using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse3D : MonoBehaviour {

    public static Mouse3D Instance { get; private set; }

    [SerializeField] private LayerMask mouseColliderLayerMask = new LayerMask();
    
    [SerializeField] private LayerMask ignoreLayerMask;
    //public GameObject canvasUI;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask & ignoreLayerMask)) {
            transform.position = raycastHit.point;
        }
    }

    public static Vector3 GetMouseWorldPosition() => Instance.GetMouseWorldPosition_Instance();

    private Vector3 GetMouseWorldPosition_Instance() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // gets the layermask index of the PanelForGrid layermask/layer
        ignoreLayerMask = LayerMask.NameToLayer("IgnoreLayer");
        
        // Sets the Gameobject Canvas UIs layer to the index of the UI layer
        //canvasUI.layer = ignoreLayerMask;
        
        if (Physics.Raycast(ray, out RaycastHit raycastHit2, 999f,  ignoreLayerMask)){
            return Vector3.zero;
        }
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f,  mouseColliderLayerMask)){
            return raycastHit.point;
        }
        else {
            //Debug.Log("Derp");
            return Vector3.zero;
        }
    }
    bool IsCanvasObject(GameObject gameObject)
    {
        return gameObject.GetComponent<Image>() != null;
    }

}
