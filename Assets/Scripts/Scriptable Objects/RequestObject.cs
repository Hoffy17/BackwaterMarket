using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Request", menuName = "Scriptable Objects/Request")]
public class RequestObject : ScriptableObject
{
    [Header("Character")]
    public string requesterName;
    [TextArea]
    public string requestMessage;

    [Header("Request")]
    public ItemType requestedItem;
    public float requestedCondition;
    public float requestOffer;

    [Header("Robbery")]
    public bool requesterIsThief;
}
