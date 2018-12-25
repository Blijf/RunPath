using UnityEngine;
using System.Collections;

public static class TimersGame
{

    public static IEnumerator waitToGo()
    {
        yield return new WaitForSeconds(4);
    }
}