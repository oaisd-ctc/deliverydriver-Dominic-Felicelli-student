using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 1.0f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("That wasn't a speed bump");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        // if (triggered object is package): print "package picked up" to the Debug Lod
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        
    }
}
