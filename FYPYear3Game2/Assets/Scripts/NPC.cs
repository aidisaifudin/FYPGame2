
using UnityEngine;


[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/New NPC")]
public class NPC : ScriptableObject { 

  
        public int npcID;
        public string npcName;
        public Message[] messages;
    

    [System.Serializable]
    public class Message
    {
        public string text;
        public Response[] responses;
    }

    [System.Serializable]
    public class Response
    {
        public int next;
        public string reply;
        public string prereq;
        public string trigger;

    }
}
