using UnityEngine;
using System.Collections;
using System.IO;

public class SearchForMp3Files : MonoBehaviour {


	string[] mp3Files;
	int count = 0;
	void Start(){
		//call DirSearch here with a starting directory

		DirSearch(@"E:\HOBBY\Projects\PROJECT_YELLOW");

		//after you get all mp3, create a tree with it and serialize the tree
		if (count == 0) {
						Debug.Log ("No directories to looooop thru");		
		} else {
			Debug.Log ("Count is "+count);		
		}
	}


	void DirSearch(string sDir) 
	{
		try	
		{
			foreach (string d in Directory.GetDirectories(sDir)) 
			{
				count++;
				foreach (string f in Directory.GetFiles(d,"*.mp3")) 
				{
					//lstFilesFound.Items.Add(f);
					Debug.Log ("File: "+f);
					getID3TagInfo(f);
					//populate List or array of mp3 files

				}
				DirSearch(d);
			}
		}
		catch (System.Exception excpt) 
		{
			Debug.Log ("File IO Problem "+excpt);
		}
	}

	//Get information from Mp3 files
	//Supports Mp3 files only for now... 

	void getID3TagInfo(string filename){
		//check for when any of the info has no value
		mp3info.mp3info mp3ID3TagInfo = new mp3info.mp3info (filename);

		mp3ID3TagInfo.ReadAll ();

		if (mp3ID3TagInfo.hasID3v1) {

			Debug.Log ("filename: "+filename +" title: "+ mp3ID3TagInfo.id3v1.Title);
			Debug.Log ("filename: "+filename +" artist: "+ mp3ID3TagInfo.id3v1.Artist);
			Debug.Log ("filename: "+filename +" year: "+ mp3ID3TagInfo.id3v1.Year);
			Debug.Log ("filename: "+filename +" album: "+ mp3ID3TagInfo.id3v1.Album);
			Debug.Log ("filename: "+filename +" length: "+mp3ID3TagInfo.length);


		}else if (mp3ID3TagInfo.hasID3v2){

			Debug.Log ("filename: "+filename +" title: "+ mp3ID3TagInfo.id3v2.Title);
			Debug.Log ("filename: "+filename +" artist: "+ mp3ID3TagInfo.id3v2.Artist);
			Debug.Log ("filename: "+filename +" year: "+ mp3ID3TagInfo.id3v2.Year);
			Debug.Log ("filename: "+filename +" album: "+ mp3ID3TagInfo.id3v2.Album);
			Debug.Log ("filename: "+filename +" length: "+ mp3ID3TagInfo.length);

		}
	}
}
