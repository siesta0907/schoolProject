using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouse : MonoBehaviour
{
    Renderer sphereRender;
    GameController gc;

    void Start() {
        GameObject pc = GameObject.Find("ProjectController");
        sphereRender = GetComponent<Renderer>();
        gc = pc.GetComponent<GameController>();
    }

    void OnMouseUp()
    {
        if (gc.selecteditems == 0) {
            gc.start = gc.name2point[name];
            sphereRender.material.color = Color.blue;
            gc.selecteditems++;
        }
        else if (gc.selecteditems == 1) {
            gc.end = gc.name2point[name];
            sphereRender.material.color = Color.red;
            gc.selecteditems++;
        }
    }
}
