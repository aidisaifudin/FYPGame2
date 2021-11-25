
using UnityEngine;

<<<<<<< Updated upstream
[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/New NPC")]
public class NPC : MonoBehaviour
=======
[CreateAssetMenu(fileName = "NPC", menuName = "Character")]
public class NPC :ScriptableObject
>>>>>>> Stashed changes
{
  
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
