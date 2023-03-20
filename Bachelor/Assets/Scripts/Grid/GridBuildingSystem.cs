using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{
    
    public Transform testTransform;
    private GridXZ<GridObject> grid;

    private void Awake(){
        int gridWidth = 25;
        int gridHeight = 25;
        float cellSize = 1f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }

    public class GridObject {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;
        private Transform transform;

        public GridObject(GridXZ<GridObject> grid, int x, int z){
            this.grid = grid;
            this.x = x;
            this.z = z;
        }
        
        public void SetTransform(Transform transform){
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, z);
        }

        public void ClearTransform(){
            transform = null;
            grid.TriggerGridObjectChanged(x, z);
        }

        // Checks if there already is a object on that grid position
        public bool CanBuild(){
            return transform == null;
        }
        
        // Text in Unity showing grid text
        public override string ToString()
        {
            return "" /*x + ", " + z + "\n"*/;
        }
    }

    private void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            // Takes world position of mouse and converts it to grid position
            // This is most likely the problem, since it spawns in the wrong position
            grid.GetXZ(Mouse3D.GetMouseWorldPosition(), out int x, out int z);

            GridObject gridObject = grid.GetGridObject(x, z);

            if (gridObject.CanBuild())
            {
                Transform builtTransform = Instantiate(testTransform, grid.GetWorldPosition(x, z), Quaternion.identity);
                gridObject.SetTransform(builtTransform);
            } else
            {
                Debug.Log("Cant build");
            }
        }
    }
}
