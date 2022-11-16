using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    //can change cursor texture in inspector
    public Texture2D cursorTexture;

    //automatically change to hardware default if necessary
    public CursorMode cursorMode = CursorMode.Auto;

    // Start is called before the first frame update
    void Start()
    {
        //set the origin to the center of the cursor texture
        Vector2 cursorOffset = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        //set the cursor to the given texture
        Cursor.SetCursor(cursorTexture, cursorOffset, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
