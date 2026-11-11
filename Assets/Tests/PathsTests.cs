
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PathsTests
{
    [UnityTest]
    public IEnumerator TestFourWaypoints()
    {
        yield return SceneManager.LoadSceneAsync("paths");

        GameObject WP1 = GameObject.Find("WP1");
        GameObject WP2 = GameObject.Find("WP2");
        GameObject WP3 = GameObject.Find("WP3");
        GameObject WP4 = GameObject.Find("WP4");

        Assert.IsNotNull(WP1, "WP1 was not found.");
        Assert.IsNotNull(WP2, "WP2 was not found.");
        Assert.IsNotNull(WP3, "WP3 was not found.");
        Assert.IsNotNull(WP4, "WP4 was not found.");
    }

    [UnityTest]
    public IEnumerator TestNPCPathController()
    {
        yield return SceneManager.LoadSceneAsync("paths");

        GameObject npc = GameObject.Find("NPC");

        Assert.IsNotNull(npc, "NPC was not found.");

        Component controller = npc.GetComponent("ControlNPC");

        Assert.IsNotNull(controller,
            "NPC does not have ControlNPC.");

        Behaviour controllerBehaviour = controller as Behaviour;

        Assert.IsNotNull(controllerBehaviour,
            "ControlNPC is not a Behaviour.");

        Assert.IsTrue(controllerBehaviour.enabled,
            "ControlNPC script is disabled.");
    }
}
