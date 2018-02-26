using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRCoder;
using UnityEngine.UI;

public class QRcode : MonoBehaviour {
	string link = "My name is jeff and i like to sing da songs of the people";

	// Use this for initialization
	void Start () {

		QRCodeGenerator qrGenerator = new QRCodeGenerator();
		QRCodeData qrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.M);

		UnityQRCode qrCode = new UnityQRCode(qrCodeData);
		Texture2D qrCodeImage = qrCode.GetGraphic(20);



		Sprite sprite = Sprite.Create (qrCodeImage, new Rect (0, 0, qrCodeImage.width, qrCodeImage.height), new Vector2 (.5f, .5f));
		Image image = this.GetComponent<Image>();
		image.sprite = sprite;
	}



	public void Assign_Data_To_QRGenerator(string DataString)
	{

		QRCodeGenerator qrGenerator = new QRCodeGenerator();
		QRCodeData qrCodeData = qrGenerator.CreateQrCode(DataString, QRCodeGenerator.ECCLevel.M);

		UnityQRCode qrCode = new UnityQRCode(qrCodeData);
		Texture2D qrCodeImage = qrCode.GetGraphic(20);



		Sprite sprite = Sprite.Create (qrCodeImage, new Rect (0, 0, qrCodeImage.width, qrCodeImage.height), new Vector2 (.5f, .5f));
		Image image = this.GetComponent<Image>();
		image.sprite = sprite;

		Debug.Log ("Data Input: " + DataString);
	}

}
