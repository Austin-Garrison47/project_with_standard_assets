
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class OffmeshTests
{
    [UnityTest]
    public IEnumerator TestNPCNavMeshAgent()
    {
        yield return SceneManager.LoadSceneAsync("offmesh");

        GameObject npc = GameObject.Find("NPC");

        Assert.IsNotNull(npc, "NPC was not found.");

        NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();

        Assert.IsNotNull(agent, "NPC has no NavMeshAgent.");
        Assert.IsTrue(agent.enabled,
            "NPC NavMeshAgent is disabled.");
    }

    [UnityTest]
    public IEnumerator TestOffMeshLink()
    {
        yield return SceneManager.LoadSceneAsync("offmesh");

        GameObject link = GameObject.Find("offMeshLink");

        Assert.IsNotNull(link, "Off-Mesh Link was not found.");

        Component navLink = link.GetComponent("NavMeshLink");

        Assert.IsNotNull(navLink,
            "NavMesh Link component was not found.");

        Behaviour linkBehaviour = navLink as Behaviour;

        Assert.IsTrue(linkBehaviour != null &&
            linkBehaviour.enabled,
            "NavMesh Link is disabled.");
    }
}
