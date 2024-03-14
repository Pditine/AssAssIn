using UnityEngine;

namespace Hmxs.Scripts
{
    public class AudioVisualizer : MonoBehaviour
    {
        //Frequencies
        [Range(0, 15)]
        //Stores which range of frequencies the object will respond to.
        public int bandFrequency;
        [Range(0.0f, 1.0f)]
        //Minimun value that the band buffer has to exceed to make the object react
        public float threshold;
        //copy of the band buffer value for being able to modify it per object
        private float changeFactor;
        //Boolean that activates all the behaviour
        public bool enable;

        //Scale
        public bool X;
        public bool Y;
        public bool Z;
        //Starting scale of the object and its multiplier.
        public float scaleMultiplier;
        private Vector3 startScale;

        //Rotation
        public bool rotate;
        public float speedMultiplier;

        //Rotation axis
        public bool RotateX;
        public bool RotateY;
        public bool RotateZ;

        //Stores the audio controller
        public AudioController audioController;


        //Material Behaviour
        static private Renderer renderColor;
        //static private Material objectMaterial;//General object's material

        private int sX = 0;
        private int sY = 0;
        private int sZ = 0;

        private int rX = 0;
        private int rY = 0;
        private int rZ = 0;

        //used for Gizmos
        Vector3 OriginalBounds;

        // Start is called before the first frame update
        void Start()
        {
            startScale = transform.localScale;      //Vector3 that will store the original scale

            OriginalBounds = transform.lossyScale;  //Gets the original bounds of the mesh for gizmos in play mode

            if (X)
                sX = 1;

            if (Y)
                sY = 1;

            if (Z)
                sZ = 1;

            if (RotateX)
                rX = 1;

            if (RotateY)
                rY = 1;

            if (RotateZ)
                rZ = 1;

            if (audioController == null)
            {//Checks that the object has an audio controller to respond to
                Debug.LogWarning("An Audio Controller must be attached to the object.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (enable && audioController != null)
            {
                //If the aplication is playing & If an audio controller is attached &
                if (audioController.audioBandBuffer[bandFrequency] >= threshold)
                {
                    //When the value exceeds the threshold
                    changeFactor = audioController.audioBandBuffer[bandFrequency];
                }
                else if (changeFactor > 0)
                {
                    //When the value exceeds the threshold
                    changeFactor = 0;
                }

                transformObject();
                rotationControl();

            }
        }

        private void transformObject()
        {
            //Transform the scale of the object on the selected axis (X,Y,Z)
            if (audioController.audioBandBuffer[bandFrequency] > 0)
                transform.localScale = new Vector3((changeFactor * scaleMultiplier * sX) + startScale.x, (changeFactor * scaleMultiplier * sY) + startScale.y, (changeFactor * scaleMultiplier * sZ) + startScale.z);

        }

        private void rotationControl()
        {
            if (rotate)
            {
                //Rotation control of the object in the X, Y and Z axis.
                transform.Rotate(changeFactor * speedMultiplier * rX, changeFactor * speedMultiplier * rY, changeFactor * speedMultiplier * rZ);
            }

        }
    }
}