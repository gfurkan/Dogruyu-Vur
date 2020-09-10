using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    [SerializeField]
    private Transform cannonHead;


    BallControl ballControl;

    public bool changeRotation = true;

    float angle;
    float donusHizi = 35;

    void Start()
    {
        changeRotation = false;
        ballControl = Object.FindObjectOfType<BallControl>();
    }

    void Update()
    {
        if (changeRotation)
        {
            ChangeRotation();
        }
    }
    void ChangeRotation()
    {
        //Mouse'la ekrana dokunulan noktanın koordinatlarını aldı.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cannonHead.transform.position;
        //Alınan koordinatların tanjantını aldı ve radyan değeri dereceye çevirdi.
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        if (angle <= 45 && angle >= -45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Objeye açıyı verdi.
            cannonHead.transform.rotation = Quaternion.Slerp(cannonHead.transform.rotation, rotation, donusHizi * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {

            float x = direction.x;
            float y = direction.y;
            
            if (y < 1.5f)
            {
                x *= 2.5f;
                y *= 2.5f;
            }
            else if (y < 2f)
            {
                x *= 1.75f;
                y *= 1.75f;
            }
            ballControl.Fire(x, y);
        }
            
            
        
    }
}
