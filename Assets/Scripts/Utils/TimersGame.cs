using UnityEngine;
using System.Collections;

public static class TimersGame
{

    public static IEnumerator waitInit()
    {
        yield return new WaitForSeconds(4);
    }
}