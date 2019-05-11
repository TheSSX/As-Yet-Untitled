using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Dynamic cursor texture changing courtesy of user TooManySugar on Unity Forums. Link: https://forum.unity.com/threads/cursor-size.288333/
public class TargetControlla : MonoBehaviour {

    public Texture2D targetReg, targetHit;
    public CursorMode cursorMode = CursorMode.Auto;
    public bool autoCenterHotSpot = true;
    public Vector2 hotSpotCustom = Vector2.zero;
    private Vector2 hotSpotAuto;
    private bool clicked = false;
    private int counter = 0;

    void Update()
    {
        if (clicked && counter < 20)
        {
            counter++;
        }
        else if (counter == 20)
        {
            counter = 0;
            clicked = false;
            target(true);
        }
    }

    public void target(bool x)
    {
        if (x)
        {
            Vector2 hotSpot;
            if (autoCenterHotSpot)
            {
                hotSpotAuto = new Vector2(targetReg.width * 0.5f, targetReg.height * 0.5f);
                hotSpot = hotSpotAuto;

            }
            else
            {
                hotSpot = hotSpotCustom;
            }

            Cursor.SetCursor(targetReg, hotSpot, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void hit()
    {
        Vector2 hotSpot;
        if (autoCenterHotSpot)
        {
            hotSpotAuto = new Vector2(targetHit.width * 0.5f, targetHit.height * 0.5f);
            hotSpot = hotSpotAuto;

        }
        else
        {
            hotSpot = hotSpotCustom;
        }

        Cursor.SetCursor(targetHit, hotSpot, CursorMode.ForceSoftware);
        clicked = true;
    }
}
