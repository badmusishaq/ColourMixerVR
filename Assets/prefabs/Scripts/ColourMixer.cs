using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ColourMix{
public class ColourMixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static CMYKColour RGBToCMYK(RGBColour colour){
		float c, m, y, k;
		k = 1 - Mathf.Max (colour.r, colour.g, colour.b);
		c = (1 - colour.r - k) / (1 - k);
		m = (1 - colour.g - k) / (1 - k);
		y = (1 - colour.b - k) / (1 - k);

		return new CMYKColour (c, m, y, k);
	}

	static RGBColour CMYKToRGB(CMYKColour colour){
		float r, g, b;
		r = (1 - colour.c) * (1 - colour.k);
		g = (1 - colour.m) * (1 - colour.k);
		b = (1 - colour.y) * (1 - colour.k);

		return new RGBColour (r, g, b);
	}

	public static RGBColour Mixer(RGBColour colour1, RGBColour colour2){
		CMYKColour cmyk1, cmyk2, cmykMix;
		cmyk1 = RGBToCMYK (colour1);
		cmyk2 = RGBToCMYK (colour2);
		cmykMix = new CMYKColour ((cmyk1.c + cmyk2.c) / 2, (cmyk1.m + cmyk2.m) / 2, (cmyk1.y + cmyk2.y) / 2, (cmyk1.k + cmyk2.k) / 2);
		RGBColour result = CMYKToRGB (cmykMix);
		return result;
	}
		

	public class CMYKColour{
		public float c, m, y, k;

		public CMYKColour(float c, float m, float y, float k){
			this.c = c;
			this.m = m;
			this.y = y;
			this.k = k;
		}
	};

	public class RGBColour{
		public float r, g, b;

		public RGBColour(float r, float g, float b){
			this.r = r;
			this.g = g;
			this.b = b;
		}
	};
}
}
