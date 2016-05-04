using UnityEngine;
using System.Collections;

public class IKPoint : MonoBehaviour
{
    public void OnDragEvent()
    {
        Ray touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = touchRay.origin + touchRay.direction * Vector3.Distance(touchRay.origin, transform.position);
    }
}
