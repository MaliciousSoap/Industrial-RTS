using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTiles : MonoBehaviour
{
    private bool pressed = false;
    public GameObject tile;
    private GameObject tileCopy;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {       
        print(gameObject.GetComponent<Button>().colors.normalColor);
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay,out RaycastHit info))
            {
                print(info.collider.gameObject.name);
                if (info.collider.gameObject.name == "Plane")
                {
                    print("hitting");
                }
                else
                {
                    print("ahhhh");
                }
            }
        }
    }
    void TaskOnClick()
    {   pressed = !pressed;

        print("pressed and pressed is now " + pressed);

        if (pressed)
        {
            tileCopy = Instantiate(tile);
        }
        else
        {
            Destroy(tileCopy);
        }


    }
}
