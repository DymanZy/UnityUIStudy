using UnityEngine;
using UnityEngine.UI;



public class CustomButton : Button
{

    private bool isInitialized = false;


    protected override void Awake() {
        if (isInitialized) return;

     
    }
}
