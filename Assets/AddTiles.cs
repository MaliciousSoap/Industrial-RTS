using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTiles : MonoBehaviour
{
    private bool pressed = false;
    public GameObject tile;
    public GameObject tilePreview;
    private Button button;
   


    private Vector3 rawContactPoint;
    private Vector3 cookedContactPoint; 

    float snapValue(float value, float snap)
    {

        return (value - (value % snap) + Mathf.Round((value % snap) / snap) * snap);
    }

    // Start is called before the first frame update
    void Start()
    {       
        //print(gameObject.GetComponent<Button>().colors.normalColor);
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
      
        
    }

    public void Build()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit info))
        {

            if (info.collider.gameObject.name == "Plane")
            {
                //                    print(info.point);
                Instantiate(tile, new Vector3(snapValue(info.point.x, 10), 0, snapValue(info.point.z, 10)),Quaternion.identity);


            }
            else
            {
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {    
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay,out RaycastHit info))
            {
               
                if (info.collider.gameObject.name == "Plane")
                {
//                    print(info.point);
                    cookedContactPoint = new Vector3(snapValue(info.point.x, 10), 0, snapValue(info.point.z, 10));
                    print(cookedContactPoint);
                    tilePreview.transform.position = cookedContactPoint;
                }
                else
                {
                }
            }
        }
    }
    void TaskOnClick()
    {   pressed = !pressed;

        print("pressed and pressed is now " + pressed);

        if (pressed)
        {
           // tilePreview = Instantiate(tile);
        }
        else
        {
            tilePreview.transform.position = new Vector3(0, -69, 0);
        }


    }
}
