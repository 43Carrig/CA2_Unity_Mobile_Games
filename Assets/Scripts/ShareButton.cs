using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Reference: Unity Social Sharing - https://www.youtube.com/watch?v=vTIBel9X3mQ

public class ShareButton : MonoBehaviour
{

    public void ClickShare()
    {
        StartCoroutine(TakeSSAndShare());
    }
    
    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        string filePath = Path.Combine( Application.temporaryCachePath, "sharedimg.png");
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );
	
        // To avoid memory leaks
        Destroy( ss );

        new NativeShare().AddFile( filePath ).SetSubject( "Random Number Generator" ).SetText( "This is My Number in the Random Number Game, what's yours!" ).Share();
    }
}
