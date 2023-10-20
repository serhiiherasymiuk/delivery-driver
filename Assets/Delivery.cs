using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new(255, 0, 0, 255);
    [SerializeField] Color32 noPackageColor = new(255, 255, 0, 255);
    [SerializeField] float destroyDelay = 0.01f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Package") && !hasPackage)
        {
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
        }
        else if (other.CompareTag("Customer") && hasPackage)
        {
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
