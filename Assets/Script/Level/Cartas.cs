using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartas : MonoBehaviour {

	public static int uno;
	public static int dos;
	public static int tres;
	public static int cuatro;
	public static int cinco;
	public static int seis;
	public static int siete;
	public static int ocho;
	public static int nueve;
	public static int diez;

	public UnityEngine.UI.Image primera;
	bool primeraListo;
	public UnityEngine.UI.Image segunda;
	bool segundaListo;
	public UnityEngine.UI.Image tercera;
	bool terceraListo;
	public UnityEngine.UI.Image cuarta;
	bool cuartaListo;
	public UnityEngine.UI.Image quinta;
	bool quintaListo;
	public UnityEngine.UI.Image sexta;
	bool sextaListo;
	public UnityEngine.UI.Image septima;
	bool septimaListo;
	public UnityEngine.UI.Image octava;
	bool octavaListo;
	public UnityEngine.UI.Image novena;
	bool novenaListo;
	public UnityEngine.UI.Image decima;
	bool decimaListo;

	//IMAGENES
	public static int seleccionada;//numero de carta seleccionda
	public Sprite blanco;//imagen cuando esta en blanco
	public Sprite imagen;//imagen de la carta seleccionada
	public Sprite a1;//----IMAGENES DE CARTAS
	public Sprite a2;
	public Sprite a3;
	public Sprite a4;
	public Sprite a5;
	public Sprite a6;
	public Sprite a7;
	public Sprite a8;
	public Sprite a9;
	public Sprite a10;
	public Sprite a11;
	public Sprite a12;
	public Sprite a13;
	public Sprite a14;
	public Sprite a15;
	public Sprite a16;
	public Sprite a17;
	public Sprite a18;
	public Sprite a19;
	public Sprite a20;

	//CANTIDAD DE LA MISMA CARTA
	public static int unoCantidad;
	public static int dosCantidad;
	public static int tresCantidad;
	public static int cuatroCantidad;
	public static int cincoCantidad;
	public static int seisCantidad;
	public static int sieteCantidad;
	public static int ochoCantidad;
	public static int nueveCantidad;
	public static int diezCantidad;

	//TEXTO CANTIDAD DE CARTAS
	public UnityEngine.UI.Text unoCantidadT;
	public UnityEngine.UI.Text dosCantidadT;
	public UnityEngine.UI.Text tresCantidadT;
	public UnityEngine.UI.Text cuatroCantidadT;
	public UnityEngine.UI.Text cincoCantidadT;
	public UnityEngine.UI.Text seisCantidadT;
	public UnityEngine.UI.Text sieteCantidadT;
	public UnityEngine.UI.Text ochoCantidadT;
	public UnityEngine.UI.Text nueveCantidadT;
	public UnityEngine.UI.Text diezCantidadT;

	// Use this for initialization
	void Start ()
	{
		uno = PlayerPrefs.GetInt("Mano1");
		dos = PlayerPrefs.GetInt("Mano2");
		tres = PlayerPrefs.GetInt("Mano3");
		cuatro = PlayerPrefs.GetInt("Mano4");
		cinco = PlayerPrefs.GetInt("Mano5");
		seis = PlayerPrefs.GetInt("Mano6");
		siete = PlayerPrefs.GetInt("Mano7");
		ocho = PlayerPrefs.GetInt("Mano8");
		nueve = PlayerPrefs.GetInt("Mano9");
		diez = PlayerPrefs.GetInt("Mano10");

		unoCantidad = PlayerPrefs.GetInt("Mano1cantidad");
		dosCantidad = PlayerPrefs.GetInt("Mano2cantidad");
		tresCantidad = PlayerPrefs.GetInt("Mano3cantidad");
		cuatroCantidad = PlayerPrefs.GetInt("Mano4cantidad");
		cincoCantidad = PlayerPrefs.GetInt("Mano5cantidad");
		seisCantidad = PlayerPrefs.GetInt("Mano6cantidad");
		sieteCantidad = PlayerPrefs.GetInt("Mano7cantidad");
		ochoCantidad = PlayerPrefs.GetInt("Mano8cantidad");
		nueveCantidad = PlayerPrefs.GetInt("Mano9cantidad");
		diezCantidad = PlayerPrefs.GetInt("Mano10cantidad");
	
		/*if(uno == 0)
		{
			uno = 1;
			dos = 2;
			tres = 3;
			cuatro = 4;
			cinco = 5;
			seis = 6;
			siete = 7;
			ocho = 8;
			nueve = 9;
			diez = 10;
		}*/
		if(uno > 0)
		{
			primeraListo = true;
			GameObject card = GameObject.Find(uno.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(dos > 0)
		{
			segundaListo = true;
			GameObject card = GameObject.Find(dos.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(tres > 0)
		{
			terceraListo = true;
			GameObject card = GameObject.Find(tres.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(cuatro > 0)
		{
			cuartaListo = true;
			GameObject card = GameObject.Find(cuatro.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(cinco > 0)
		{
			quintaListo = true;
			GameObject card = GameObject.Find(cinco.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(seis > 0)
		{
			sextaListo = true;
			GameObject card = GameObject.Find(seis.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(siete > 0)
		{
			septimaListo = true;
			GameObject card = GameObject.Find(siete.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(ocho > 0)
		{
			octavaListo = true;
			GameObject card = GameObject.Find(ocho.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(nueve > 0)
		{
			novenaListo = true;
			GameObject card = GameObject.Find(nueve.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		if(diez > 0)
		{
			decimaListo = true;
			GameObject card = GameObject.Find(diez.ToString());
			card.GetComponent<Cards>().usada = true;
		}
		//UNO
		if(uno == 1)
		{
			primera.sprite = a1;
		}else if(uno == 2)
		{
			primera.sprite = a2;
		}else if(uno == 3)
		{
			primera.sprite = a3;
		}else if(uno == 4)
		{
			primera.sprite = a4;
		}else if(uno == 5)
		{
			primera.sprite = a5;
		}else if(uno == 6)
		{
			primera.sprite = a6;
		}else if(uno == 7)
		{
			primera.sprite = a7;
		}else if(uno == 8)
		{
			primera.sprite = a8;
		}else if(uno == 9)
		{
			primera.sprite = a9;
		}else if(uno == 10)
		{
			primera.sprite = a10;
		}else if(uno == 11)
		{
			primera.sprite = a11;
		}else if(uno == 12)
		{
			primera.sprite = a12;
		}else if(uno == 13)
		{
			primera.sprite = a13;
		}else if(uno == 14)
		{
			primera.sprite = a14;
		}else if(uno == 15)
		{
			primera.sprite = a15;
		}else if(uno == 16)
		{
			primera.sprite = a16;
		}else if(uno == 17)
		{
			primera.sprite = a17;
		}else if(uno == 18)
		{
			primera.sprite = a18;
		}else if(uno == 19)
		{
			primera.sprite = a19;
		}else if(uno == 20)
		{
			primera.sprite = a20;
		}
		//DOS
		if(dos == 1)
		{
			segunda.sprite = a1;
		}else if(dos == 2)
		{
			segunda.sprite = a2;
		}else if(dos == 3)
		{
			segunda.sprite = a3;
		}else if(dos == 4)
		{
			segunda.sprite = a4;
		}else if(dos == 5)
		{
			segunda.sprite = a5;
		}else if(dos == 6)
		{
			segunda.sprite = a6;
		}else if(dos == 7)
		{
			segunda.sprite = a7;
		}else if(dos == 8)
		{
			segunda.sprite = a8;
		}else if(dos == 9)
		{
			segunda.sprite = a9;
		}else if(dos == 10)
		{
			segunda.sprite = a10;
		}else if(dos == 11)
		{
			segunda.sprite = a11;
		}else if(dos == 12)
		{
			segunda.sprite = a12;
		}else if(dos == 13)
		{
			segunda.sprite = a13;
		}else if(dos == 14)
		{
			segunda.sprite = a14;
		}else if(dos == 15)
		{
			segunda.sprite = a15;
		}else if(dos == 16)
		{
			segunda.sprite = a16;
		}else if(dos == 17)
		{
			segunda.sprite = a17;
		}else if(dos == 18)
		{
			segunda.sprite = a18;
		}else if(dos == 19)
		{
			segunda.sprite = a19;
		}else if(dos == 20)
		{
			segunda.sprite = a20;
		}
		//TRES
		if(tres == 1)
		{
			tercera.sprite = a1;
		}else if(tres == 2)
		{
			tercera.sprite = a2;
		}else if(tres == 3)
		{
			tercera.sprite = a3;
		}else if(tres == 4)
		{
			tercera.sprite = a4;
		}else if(tres == 5)
		{
			tercera.sprite = a5;
		}else if(tres == 6)
		{
			tercera.sprite = a6;
		}else if(tres == 7)
		{
			tercera.sprite = a7;
		}else if(tres == 8)
		{
			tercera.sprite = a8;
		}else if(tres == 9)
		{
			tercera.sprite = a9;
		}else if(tres == 10)
		{
			tercera.sprite = a10;
		}else if(tres == 11)
		{
			tercera.sprite = a11;
		}else if(tres == 12)
		{
			tercera.sprite = a12;
		}else if(tres == 13)
		{
			tercera.sprite = a13;
		}else if(tres == 14)
		{
			tercera.sprite = a14;
		}else if(tres == 15)
		{
			tercera.sprite = a15;
		}else if(tres == 16)
		{
			tercera.sprite = a16;
		}else if(tres == 17)
		{
			tercera.sprite = a17;
		}else if(tres == 18)
		{
			tercera.sprite = a18;
		}else if(tres == 19)
		{
			tercera.sprite = a19;
		}else if(tres == 20)
		{
			tercera.sprite = a20;
		}
		//CUATRO
		if(cuatro == 1)
		{
			cuarta.sprite = a1;
		}else if(cuatro == 2)
		{
			cuarta.sprite = a2;
		}else if(cuatro == 3)
		{
			cuarta.sprite = a3;
		}else if(cuatro == 4)
		{
			cuarta.sprite = a4;
		}else if(cuatro == 5)
		{
			cuarta.sprite = a5;
		}else if(cuatro == 6)
		{
			cuarta.sprite = a6;
		}else if(cuatro == 7)
		{
			cuarta.sprite = a7;
		}else if(cuatro == 8)
		{
			cuarta.sprite = a8;
		}else if(cuatro == 9)
		{
			cuarta.sprite = a9;
		}else if(cuatro == 10)
		{
			cuarta.sprite = a10;
		}else if(cuatro == 11)
		{
			cuarta.sprite = a11;
		}else if(cuatro == 12)
		{
			cuarta.sprite = a12;
		}else if(cuatro == 13)
		{
			cuarta.sprite = a13;
		}else if(cuatro == 14)
		{
			cuarta.sprite = a14;
		}else if(cuatro == 15)
		{
			cuarta.sprite = a15;
		}else if(cuatro == 16)
		{
			cuarta.sprite = a16;
		}else if(cuatro == 17)
		{
			cuarta.sprite = a17;
		}else if(cuatro == 18)
		{
			cuarta.sprite = a18;
		}else if(cuatro == 19)
		{
			cuarta.sprite = a19;
		}else if(cuatro == 20)
		{
			cuarta.sprite = a20;
		}
		//CINCO
		if(cinco == 1)
		{
			quinta.sprite = a1;
		}else if(cinco == 2)
		{
			quinta.sprite = a2;
		}else if(cinco == 3)
		{
			quinta.sprite = a3;
		}else if(cinco == 4)
		{
			quinta.sprite = a4;
		}else if(cinco == 5)
		{
			quinta.sprite = a5;
		}else if(cinco == 6)
		{
			quinta.sprite = a6;
		}else if(cinco == 7)
		{
			quinta.sprite = a7;
		}else if(cinco == 8)
		{
			quinta.sprite = a8;
		}else if(cinco == 9)
		{
			quinta.sprite = a9;
		}else if(cinco == 10)
		{
			quinta.sprite = a10;
		}else if(cinco == 11)
		{
			quinta.sprite = a11;
		}else if(cinco == 12)
		{
			quinta.sprite = a12;
		}else if(cinco == 13)
		{
			quinta.sprite = a13;
		}else if(cinco == 14)
		{
			quinta.sprite = a14;
		}else if(cinco == 15)
		{
			quinta.sprite = a15;
		}else if(cinco == 16)
		{
			quinta.sprite = a16;
		}else if(cinco == 17)
		{
			quinta.sprite = a17;
		}else if(cinco == 18)
		{
			quinta.sprite = a18;
		}else if(cinco == 19)
		{
			quinta.sprite = a19;
		}else if(cinco == 20)
		{
			quinta.sprite = a20;
		}
		//SEIS
		if(seis == 1)
		{
			sexta.sprite = a1;
		}else if(seis == 2)
		{
			sexta.sprite = a2;
		}else if(seis == 3)
		{
			sexta.sprite = a3;
		}else if(seis == 4)
		{
			sexta.sprite = a4;
		}else if(seis == 5)
		{
			sexta.sprite = a5;
		}else if(seis == 6)
		{
			sexta.sprite = a6;
		}else if(seis == 7)
		{
			sexta.sprite = a7;
		}else if(seis == 8)
		{
			sexta.sprite = a8;
		}else if(seis == 9)
		{
			sexta.sprite = a9;
		}else if(seis == 10)
		{
			sexta.sprite = a10;
		}else if(seis == 11)
		{
			sexta.sprite = a11;
		}else if(seis == 12)
		{
			sexta.sprite = a12;
		}else if(seis == 13)
		{
			sexta.sprite = a13;
		}else if(seis == 14)
		{
			sexta.sprite = a14;
		}else if(seis == 15)
		{
			sexta.sprite = a15;
		}else if(seis == 16)
		{
			sexta.sprite = a16;
		}else if(seis == 17)
		{
			sexta.sprite = a17;
		}else if(seis == 18)
		{
			sexta.sprite = a18;
		}else if(seis == 19)
		{
			sexta.sprite = a19;
		}else if(seis == 20)
		{
			sexta.sprite = a20;
		}
		//SIETE
		if(siete == 1)
		{
			septima.sprite = a1;
		}else if(siete == 2)
		{
			septima.sprite = a2;
		}else if(siete == 3)
		{
			septima.sprite = a3;
		}else if(siete == 4)
		{
			septima.sprite = a4;
		}else if(siete == 5)
		{
			septima.sprite = a5;
		}else if(siete == 6)
		{
			septima.sprite = a6;
		}else if(siete == 7)
		{
			septima.sprite = a7;
		}else if(siete == 8)
		{
			septima.sprite = a8;
		}else if(siete == 9)
		{
			septima.sprite = a9;
		}else if(siete == 10)
		{
			septima.sprite = a10;
		}else if(siete == 11)
		{
			septima.sprite = a11;
		}else if(siete == 12)
		{
			septima.sprite = a12;
		}else if(siete == 13)
		{
			septima.sprite = a13;
		}else if(siete == 14)
		{
			septima.sprite = a14;
		}else if(siete == 15)
		{
			septima.sprite = a15;
		}else if(siete == 16)
		{
			septima.sprite = a16;
		}else if(siete == 17)
		{
			septima.sprite = a17;
		}else if(siete == 18)
		{
			septima.sprite = a18;
		}else if(siete == 19)
		{
			septima.sprite = a19;
		}else if(siete == 20)
		{
			septima.sprite = a20;
		}
		//OCHO
		if(ocho == 1)
		{
			octava.sprite = a1;
		}else if(ocho == 2)
		{
			octava.sprite = a2;
		}else if(ocho == 3)
		{
			octava.sprite = a3;
		}else if(ocho == 4)
		{
			octava.sprite = a4;
		}else if(ocho == 5)
		{
			octava.sprite = a5;
		}else if(ocho == 6)
		{
			octava.sprite = a6;
		}else if(ocho == 7)
		{
			octava.sprite = a7;
		}else if(ocho == 8)
		{
			octava.sprite = a8;
		}else if(ocho == 9)
		{
			octava.sprite = a9;
		}else if(ocho == 10)
		{
			octava.sprite = a10;
		}else if(ocho == 11)
		{
			octava.sprite = a11;
		}else if(ocho == 12)
		{
			octava.sprite = a12;
		}else if(ocho == 13)
		{
			octava.sprite = a13;
		}else if(ocho == 14)
		{
			octava.sprite = a14;
		}else if(ocho == 15)
		{
			octava.sprite = a15;
		}else if(ocho == 16)
		{
			octava.sprite = a16;
		}else if(ocho == 17)
		{
			octava.sprite = a17;
		}else if(ocho == 18)
		{
			octava.sprite = a18;
		}else if(ocho == 19)
		{
			octava.sprite = a19;
		}else if(ocho == 20)
		{
			octava.sprite = a20;
		}
		//NUEVE
		if(nueve == 1)
		{
			novena.sprite = a1;
		}else if(nueve == 2)
		{
			novena.sprite = a2;
		}else if(nueve == 3)
		{
			novena.sprite = a3;
		}else if(nueve == 4)
		{
			novena.sprite = a4;
		}else if(nueve == 5)
		{
			novena.sprite = a5;
		}else if(nueve == 6)
		{
			novena.sprite = a6;
		}else if(nueve == 7)
		{
			novena.sprite = a7;
		}else if(nueve == 8)
		{
			novena.sprite = a8;
		}else if(nueve == 9)
		{
			novena.sprite = a9;
		}else if(nueve == 10)
		{
			novena.sprite = a10;
		}else if(nueve == 11)
		{
			novena.sprite = a11;
		}else if(nueve == 12)
		{
			novena.sprite = a12;
		}else if(nueve == 13)
		{
			novena.sprite = a13;
		}else if(nueve == 14)
		{
			novena.sprite = a14;
		}else if(nueve == 15)
		{
			novena.sprite = a15;
		}else if(nueve == 16)
		{
			novena.sprite = a16;
		}else if(nueve == 17)
		{
			novena.sprite = a17;
		}else if(nueve == 18)
		{
			novena.sprite = a18;
		}else if(nueve == 19)
		{
			novena.sprite = a19;
		}else if(nueve == 20)
		{
			novena.sprite = a20;
		}
		//DIEZ
		if(diez == 1)
		{
			decima.sprite = a1;
		}else if(diez == 2)
		{
			decima.sprite = a2;
		}else if(diez == 3)
		{
			decima.sprite = a3;
		}else if(diez == 4)
		{
			decima.sprite = a4;
		}else if(diez == 5)
		{
			decima.sprite = a5;
		}else if(diez == 6)
		{
			decima.sprite = a6;
		}else if(diez == 7)
		{
			decima.sprite = a7;
		}else if(diez == 8)
		{
			decima.sprite = a8;
		}else if(diez == 9)
		{
			decima.sprite = a9;
		}else if(diez == 10)
		{
			decima.sprite = a10;
		}else if(diez == 11)
		{
			decima.sprite = a11;
		}else if(diez == 12)
		{
			decima.sprite = a12;
		}else if(diez == 13)
		{
			decima.sprite = a13;
		}else if(diez == 14)
		{
			decima.sprite = a14;
		}else if(diez == 15)
		{
			decima.sprite = a15;
		}else if(diez == 16)
		{
			decima.sprite = a16;
		}else if(diez == 17)
		{
			decima.sprite = a17;
		}else if(diez == 18)
		{
			decima.sprite = a18;
		}else if(diez == 19)
		{
			decima.sprite = a19;
		}else if(diez == 20)
		{
			decima.sprite = a20;
		}
		//SET CANTIDAD PARA ACTUALIZAR GLOBALES
		PlayerPrefs.SetInt("card"+uno+"cantidadUsadas", unoCantidad);
		PlayerPrefs.SetInt("card"+dos+"cantidadUsadas", dosCantidad);
		PlayerPrefs.SetInt("card"+tres+"cantidadUsadas", tresCantidad);
		PlayerPrefs.SetInt("card"+cuatro+"cantidadUsadas", cuatroCantidad);
		PlayerPrefs.SetInt("card"+cinco+"cantidadUsadas", cincoCantidad);
		PlayerPrefs.SetInt("card"+seis+"cantidadUsadas", seisCantidad);
		PlayerPrefs.SetInt("card"+siete+"cantidadUsadas", sieteCantidad);
		PlayerPrefs.SetInt("card"+ocho+"cantidadUsadas", ochoCantidad);
		PlayerPrefs.SetInt("card"+nueve+"cantidadUsadas", nueveCantidad);
		PlayerPrefs.SetInt("card"+diez+"cantidadUsadas", diezCantidad);
	}
	
	// Update is called once per frame
	void Update ()
	{
		unoCantidadT.text = unoCantidad.ToString();
		dosCantidadT.text = dosCantidad.ToString();
		tresCantidadT.text = tresCantidad.ToString();
		cuatroCantidadT.text = cuatroCantidad.ToString();
		cincoCantidadT.text = cincoCantidad.ToString();
		seisCantidadT.text = seisCantidad.ToString();
		sieteCantidadT.text = sieteCantidad.ToString();
		ochoCantidadT.text = ochoCantidad.ToString();
		nueveCantidadT.text = nueveCantidad.ToString();
		diezCantidadT.text = diezCantidad.ToString();

		if(seleccionada == 1)
		{
			imagen = a1;
		}else if(seleccionada == 2)
		{
			imagen = a2;
		}else if(seleccionada == 3)
		{
			imagen = a3;
		}else if(seleccionada == 4)
		{
			imagen = a4;
		}else if(seleccionada == 5)
		{
			imagen = a5;
		}else if(seleccionada == 6)
		{
			imagen = a6;
		}else if(seleccionada == 7)
		{
			imagen = a7;
		}else if(seleccionada == 8)
		{
			imagen = a8;
		}else if(seleccionada == 9)
		{
			imagen = a9;
		}else if(seleccionada == 10)
		{
			imagen = a10;
		}else if(seleccionada == 11)
		{
			imagen = a11;
		}else if(seleccionada == 12)
		{
			imagen = a12;
		}else if(seleccionada == 13)
		{
			imagen = a13;
		}else if(seleccionada == 14)
		{
			imagen = a14;
		}else if(seleccionada == 15)
		{
			imagen = a15;
		}else if(seleccionada == 16)
		{
			imagen = a16;
		}else if(seleccionada == 17)
		{
			imagen = a17;
		}else if(seleccionada == 18)
		{
			imagen = a18;
		}else if(seleccionada == 19)
		{
			imagen = a19;
		}else if(seleccionada == 20)
		{
			imagen = a20;
		}

		//IMAGEN
		if(uno == 0)
		{
			primera.sprite = blanco;
		}else if(!primeraListo)
		{
			uno = seleccionada;
			primera.sprite = imagen;
			primeraListo = true;
		}
		if(dos == 0)
		{
			segunda.sprite = blanco;
		}else if(!segundaListo)
		{
			dos = seleccionada;
			segunda.sprite = imagen;
			segundaListo = true;
		}
		if(tres == 0)
		{
			tercera.sprite = blanco;
		}else if(!terceraListo)
		{
			tres = seleccionada;
			tercera.sprite = imagen;
			terceraListo = true;
		}
		if(cuatro == 0)
		{
			cuarta.sprite = blanco;
		}else if(!cuartaListo)
		{
			cuatro = seleccionada;
			cuarta.sprite = imagen;
			cuartaListo = true;
		}
		if(cinco == 0)
		{
			quinta.sprite = blanco;
		}else if(!quintaListo)
		{
			cinco = seleccionada;
			quinta.sprite = imagen;
			quintaListo = true;
		}
		if(seis == 0)
		{
			sexta.sprite = blanco;
		}else if(!sextaListo)
		{
			seis = seleccionada;
			sexta.sprite = imagen;
			sextaListo = true;
		}
		if(siete == 0)
		{
			septima.sprite = blanco;
		}else if(!septimaListo)
		{
			siete = seleccionada;
			septima.sprite = imagen;
			septimaListo = true;
		}
		if(ocho == 0)
		{
			octava.sprite = blanco;
		}else if(!octavaListo)
		{
			ocho = seleccionada;
			octava.sprite = imagen;
			octavaListo = true;
		}
		if(nueve == 0)
		{
			novena.sprite = blanco;
		}else if(!novenaListo)
		{
			nueve = seleccionada;
			novena.sprite = imagen;
			novenaListo = true;
		}
		if(diez == 0)
		{
			decima.sprite = blanco;
		}else if(!decimaListo)
		{
			diez = seleccionada;
			decima.sprite = imagen;
			decimaListo = true;
		}
	}

	public void cambiar1 ()
	{
		if(uno != 0)
		{
			GameObject card = GameObject.Find(uno.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(unoCantidad >= 2)
			{
				unoCantidad -= 1;
			}else
			{
				primeraListo = false;
				unoCantidad = 0;
				uno = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar2 ()
	{
		if(dos != 0)
		{
			GameObject card = GameObject.Find(dos.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(dosCantidad >= 2)
			{
				dosCantidad -= 1;
			}else
			{
				segundaListo = false;
				dosCantidad = 0;
				dos = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar3 ()
	{
		if(tres != 0)
		{
			GameObject card = GameObject.Find(tres.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(tresCantidad >= 2)
			{
				tresCantidad -= 1;
			}else
			{
				terceraListo = false;
				tresCantidad = 0;
				tres = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar4 ()
	{
		if(cuatro != 0)
		{
			GameObject card = GameObject.Find(cuatro.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(cuatroCantidad >= 2)
			{
				cuatroCantidad -= 1;
			}else
			{
				cuartaListo = false;
				cuatroCantidad = 0;
				cuatro = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar5 ()
	{
		if(cinco != 0)
		{
			GameObject card = GameObject.Find(cinco.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(cincoCantidad >= 2)
			{
				cincoCantidad -= 1;
			}else
			{
				quintaListo = false;
				cincoCantidad = 0;
				cinco = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar6 ()
	{
		if(seis != 0)
		{
			GameObject card = GameObject.Find(seis.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(seisCantidad >= 2)
			{
				seisCantidad -= 1;
			}else
			{
				sextaListo = false;
				seisCantidad = 0;
				seis = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar7 ()
	{
		if(siete != 0)
		{
			GameObject card = GameObject.Find(siete.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(sieteCantidad >= 2)
			{
				sieteCantidad -= 1;
			}else
			{
				septimaListo = false;
				sieteCantidad = 0;
				siete = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar8 ()
	{
		if(ocho != 0)
		{
			GameObject card = GameObject.Find(ocho.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(ochoCantidad >= 2)
			{
				ochoCantidad -= 1;
			}else
			{
				octavaListo = false;
				ochoCantidad = 0;
				ocho = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar9 ()
	{
		if(nueve != 0)
		{
			GameObject card = GameObject.Find(nueve.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(nueveCantidad >= 2)
			{
				nueveCantidad -= 1;
			}else
			{
				novenaListo = false;
				nueveCantidad = 0;
				nueve = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}
	public void cambiar10 ()
	{
		if(diez != 0)
		{
			GameObject card = GameObject.Find(diez.ToString());
			card.GetComponent<Cards>().cantidad += 1;

			if(diezCantidad >= 2)
			{
				diezCantidad -= 1;
			}else
			{
				decimaListo = false;
				diezCantidad = 0;
				diez = 0;
			}
			card.GetComponent<Cards>().usada = false;
		}
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().clip = selec;
		GetComponent<AudioSource>().Play();
	}

	public AudioClip selec;
}
