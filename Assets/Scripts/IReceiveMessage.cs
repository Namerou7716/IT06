using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IReceiveMessage : IEventSystemHandler
{
   void OnReceive(string showText); 
}














