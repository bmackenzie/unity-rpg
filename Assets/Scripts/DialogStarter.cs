//Script for letting the character activate Yarn Conversations
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Yarn.Unity
{
    public class DialogStarter : MonoBehaviour
    {

        public float interactionRadius = 2.0f;

        //contains whether or not dialogue is being run
        bool isActive = false;

        /// Draw the range at which we'll start talking to people.
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, 1, 0));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
        }

        /// Update is called once per frame
        void Update()
        {

            // Detect if we want to start a conversation
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckForNearbyNPC();
            }

            //checks if there is active dialogue, stops player from moving if there is
            isActive = !(FindObjectOfType<DialogueRunner>().IsDialogueRunning);
            GameManager.instance.dialogueActive = !isActive;
        }

        /// Find all DialogueParticipants
        /** Filter them to those that have a Yarn start node and are in range; 
         * then start a conversation with the first one
         */
        public void CheckForNearbyNPC()
        {
            var allParticipants = new List<Talkable>(FindObjectsOfType<Talkable>());
            var target = allParticipants.Find(delegate (Talkable p) {
                return string.IsNullOrEmpty(p.talkToNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });
            if (target != null)
            {
                // Kick off the dialogue at this node.
                FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);
            }
        }
    }
}
