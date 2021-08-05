using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Varuautomat.Modell {
    ///
    ///
    public abstract class Peng : IComparable {
	public class PengJämförare : IComparer {
	    ///<summary>alternativ för sorteringen
	    ///</summary>
	    public enum JämförMellan {
		Namn,    // sortera på namn i bokstavsordning
		Valör    // -*-     efter valör i sjunkande ordning
	    };

	    ///<summary>specialjämförare som kan jämföra mellan valör eller namn
	    ///</summary>
	    public int Compare( object vänsterSida, object högerSida) {
		Peng vänster = (Peng) vänsterSida;
		Peng höger   = (Peng) högerSida;
		return vänster.CompareTo( höger, ValtPredikat);
	    }

	    private Peng.PengJämförare.JämförMellan valtPredikat;
	    public  Peng.PengJämförare.JämförMellan ValtPredikat {
		get { return valtPredikat;  }
		set { valtPredikat = value; }
	    }
	}

	// public static PengJämförare AllokeraJämförare()
	// {
	//     return new Peng.PengJämförare();
	// }

	//
	// normal vanlig som ska jämföra efter namn
	//
	public int CompareTo( Object rhs) {
	    Peng r = (Peng) rhs;
	    return this.namn.CompareTo( r.namn);
	}

	//
	// en special där vad som ska jämföras är valbart
	//
	public int CompareTo( Peng                            rhs,
			      Peng.PengJämförare.JämförMellan valtPredikat) {
	    switch (valtPredikat) {
		case Peng.PengJämförare.JämförMellan.Namn:
		    return this.namn.CompareTo( rhs.namn);
		case Peng.PengJämförare.JämförMellan.Valör:
		    return this.namn.CompareTo( rhs.valör);
	    }
	    return 0;
	}

	private string namn;
	public  string Namn {
	    get { return namn; }
	}

	private int valör;
	public int  Valör {
	    get { return valör; }
	}

	public Peng( string namn, int valör) {
	    this.namn  = namn;
	    this.valör = valör;
	}

	public override string ToString()
	{
	    return "Namn: " + Namn + " Valör: " + valör.ToString();
	}
    }

    /// <summary>accepterade betalningsmedel vid kreditering (inmatning av pengar) till kundsaldo
    /// inmatningsutrustningen finns i två typer: för sedlar och mynt
    /// </summary
    public class Mynt:Peng {
	private  float    diameter;
	private string beskrivning;
	private string    material;

	public float     Diameter { get {    return diameter; }}
	public string    Material { get {    return material; }}
	public string Beskrivning { get { return beskrivning; }}
	public Mynt(string namn, int värde, float diameter, string beskrivning, string material):base(namn, värde) {
	    this.diameter    = diameter;
	    this.beskrivning = beskrivning;
	    this.material    = material;
	}
    }

    public class Sedel:Peng {
	private string beskrivning_verso; // framsida
	private string beskrivning_recto; // baksida

	public string Verso { get { return beskrivning_verso; }}
	public string Recto { get { return beskrivning_recto; }}
	public Sedel( string namn, int värde, string beskrivning_verso, string beskrivning_recto):base(namn,värde) {
	    this.beskrivning_verso = beskrivning_verso;
	    this.beskrivning_recto = beskrivning_recto;
	}
    }

    public class AccepteradeBetalningsmedel {
	//                                   diameter(mm) namn     material
	//  1 kungen i profil, från vänster  19,5         1-krona  "koppar-pläterat stål"
	//  5 kungens namnchiffer           23,75         5-krona  "nordiskt guld"
	// 10 kungen i profil, från vänster  20,5         10-krona "nordiskt guld"
	//   20   Astrid
	//   50   Evert
	//  100   Greta
	//  200   Ingmar
	//  500   Birgit Nilsson
	// 1000   Dag Hammarskjöld
	List<Peng> accepteradValörer = new List<Peng>();

	public AccepteradeBetalningsmedel() {
	    //
	    // huller om buller för att kunna kontrollera att sorteringen av de sedan fungerar
	    //
	    accepteradValörer.Add(new Mynt(  "5-krona",   5, 23.75F, "kungens namnchiffer",           "nordiskt guld"));
	    accepteradValörer.Add(new Mynt(  "10-krona", 10, 20.50F, "kungen i profil, från vänster", "nordiskt guld"));
	    accepteradValörer.Add(new Mynt(  "kungen",    1, 19.50F, "kungen i profil, från vänster", "koppar-pläterat stål, kopparfärgat"));  // från Oskar II: mynt med kungens profil

	    accepteradValörer.Add(new Sedel( "Greta",   100, "Greta Garbo",      "Stockholm, Gamla stanvy"));
	    accepteradValörer.Add(new Sedel( "Ingmar",  200, "Ingmar Bergman",   "Gotland, Gotlandsraukar"));
	    accepteradValörer.Add(new Sedel( "Astrid",   20, "Astrid Lindgren",  "Småland, Linnés egen blomma - Linnea"));
	    accepteradValörer.Add(new Sedel( "Evert",    50, "Evert Taube",      "Bohuslän, båt från hällristning"));
	    accepteradValörer.Add(new Sedel( "Birgit",  500, "Birgit Nilsson",   "Skåne, Öresundsbron"));
	    accepteradValörer.Add(new Sedel( "Dag",    1000, "Dag Hammarskjöld", "Laponia"));

	    accepteradValörer.Sort(JämförValör);   // sortera i sjunkande ordning, behövs för EndTransactions uppräkning av växel
	}

	// låt myntinkastet få veta om något är OK
	public bool accepterasMyntet(string namn) {
	    foreach (Peng peng in accepteradValörer)
		if ((peng is Mynt) & (namn==peng.Namn)) {
		    return true;
		}
	    return false;
	}
	public bool accepterasSedeln(string namn) {
	    foreach (Peng peng in accepteradValörer)
		if ((peng is Sedel) & (namn == peng.Namn)) {
		    return true;
		}
	    return false;
	}
	public bool accepterasPeng(string namn) {
	    foreach (Peng peng in accepteradValörer)
		if (namn == peng.Namn) {
		    return true;
		}
	    return false;
	}

	//
	// returnera en matris/lista med namnen all accepterade mynt
	//
	public string[] allaAccepteradeMynt() {
	    int      i=0;
	    string[] allaMynt  = new string[0];

	    foreach (Peng peng in accepteradValörer)
		if (peng is Mynt) {
		    string[] nyAllaMynt = new string[i+1];
		    Array.Copy( allaMynt, nyAllaMynt, i);
		    nyAllaMynt[i] = peng.Namn;
		    allaMynt = nyAllaMynt;
		    i++;
		}

	    return allaMynt;
	}
	//
	// returnera en matris/lista med namnen för alla accepterade sedlar
	//
	public string[] allaAccepteradeSedlar() {
	    int    i=0;
	    string[] allaSedlar = new string[0];

	    foreach (Peng peng in accepteradValörer)
		if (peng is Sedel) {
		    string[] nyAllaSedlar = new string[i+1];
		    Array.Copy( allaSedlar, nyAllaSedlar, i);
		    nyAllaSedlar[i]= peng.Namn;
		    allaSedlar = nyAllaSedlar;
		    i++;
		}

	    return allaSedlar;
	}
	//
	// returnera en matris/lista med namnen för alla accepterade sedlar
	//
	public string[] allaAccepteradeBetalningsmedel() {
	    int i = 0;
	    string[] allaAccepteradeBetalningsmedel  = new string[accepteradValörer.Count];
	    foreach (Peng peng in accepteradValörer)
		allaAccepteradeBetalningsmedel[i++]=peng.Namn;

	    return allaAccepteradeBetalningsmedel;
	}

	/// <summary> sortera valörer i sjunkande ordning
	/// </summary>
	private static int JämförValör(Peng lhs, Peng rhs) {
	    if (lhs==null) {
		if (rhs==null) { // båda två är lika med null
		    return 0;
		} else {
		    return -1;   // bara l är null
		}
	    } else {
		if (rhs==null) {   // l != null men r == null
		    return 1;
		} else {
		    if (lhs.Valör < rhs.Valör) {
			return 0;
		    }
		    else
			return -1;
		}
	    }
	}

	/// <summary> sortera i sjunkande valörer dvs högst valör först
	/// </summary>
	public void sorteradEfterValör()
	{
	    // Peng.PengJämförare jämförVal = Peng.AllokeraJämförare();
	    // jämförVal.ValtPredikat = Peng.PengJämförare.JämförMellan.Valör;
	    // accepteradValörer.Sort(jämförVal);
	    accepteradValörer.Sort(JämförValör);
	}

	/// <summary>
	/// hur mycket är sedeln/myntet värt ?
	/// </summary>
	public int Värde(string namn) {
	    bool hittad = false;  /// error
	    int  värde=0;

	    foreach (Peng peng in accepteradValörer)
		if (namn==peng.Namn) {
		    värde = peng.Valör;
		    hittad=true;
		    break;
		}
	    if(!hittad)
		throw new ArgumentException( "ej accepterad valör");
	    return värde;
	}
    }
}
