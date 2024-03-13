using System.Collections.Generic;
using UnityEngine;

public static class InputValid
{
    private static List<KeyCode> enabledKeys = new();

    public static void EnableKey(KeyCode key)
    {
        if (!enabledKeys.Contains(key))
            enabledKeys.Add(key);
    }

    public static void DisableKey(KeyCode key)
    {
        if (!enabledKeys.Contains(key))
            enabledKeys.Add(key);
    }

    public static bool KeyIsEnabled(KeyCode key)
    {
        return enabledKeys.Contains(key);
    }

    public static bool GetKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key) && enabledKeys.Contains(key);
    }

    public static bool GetKey(KeyCode key)
    {
        return Input.GetKey(key) && enabledKeys.Contains(key);
    }

    public static bool GetKeyUp(KeyCode key)
    {
        return Input.GetKeyUp(key) && enabledKeys.Contains(key);
    }
}
