using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_cursor : MonoBehaviour
{
    public Texture2D default_cursorTexture;

    public CursorMode cursorMode = CursorMode.Auto;

    public Vector2 hotSpot = Vector2.zero;

    public Texture2D cursorOnClue;

    public void change_cursor_to_default()
    {
        Cursor.SetCursor(default_cursorTexture, hotSpot, cursorMode);
    }

    public void cursor_on_clue()
    {
        Cursor.SetCursor(cursorOnClue, Vector2.zero, cursorMode);
    }
}
