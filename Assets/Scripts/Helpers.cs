using UnityEngine;

public static class Helpers
{
    private static Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    public static Vector3 ToIso(this Vector3 input) => isoMatrix.MultiplyPoint3x4(input);

    public static bool GroundDetection(this Transform thisTransform, float checkDistance, LayerMask groundLayer)
    {
        Ray ray = new(thisTransform.position, Vector3.down);
        if(Physics.Raycast(ray, checkDistance, groundLayer))
        {
           return true;
        }else{
            return false;
        }
    }


    //call Helpers.RandomizeAudio(yourAudioSource) to create variations of your sound effects, 
    //then call yourAudioSource.PlayOneShot(yourAudioClip).
    //particularly useful when multiple audio sources play the same clip often or at the same time in your scene (which can create distortion)
    public static void RandomizeAudio(AudioSource audioSource)
    {
        int randPriority = Random.Range(125, 200);
        audioSource.priority = randPriority;

        float randVolume = Random.Range(0.1f, 0.3f);
        audioSource.volume = randVolume;

        float randPitch = Random.Range(0.8f, 1.2f);
        audioSource.pitch = randPitch;
    }
}
