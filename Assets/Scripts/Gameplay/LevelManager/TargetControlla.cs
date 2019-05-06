using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Dynamic cursor texture changing courtesy of user TooManySugar on Unity Forums. Link: https://forum.unity.com/threads/cursor-size.288333/
public class TargetControlla : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public bool autoCenterHotSpot = true;
    public Vector2 hotSpotCustom = Vector2.zero;
    private Vector2 hotSpotAuto;

    public void target(bool x)
    {
        if (x)
        {
            Vector2 hotSpot;
            if (autoCenterHotSpot)
            {
                hotSpotAuto = new Vector2(cursorTexture.width * 0.5f, cursorTexture.height * 0.5f);
                hotSpot = hotSpotAuto;

            }
            else
            {
                hotSpot = hotSpotCustom;
            }

            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
