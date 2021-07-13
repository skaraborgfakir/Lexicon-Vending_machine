using System;
using System.Collections.Generic;

namespace Varuautomat.Modell {
    /// <summary>accepterade betalningsmedel vid kreditering (inmatning av pengar) till kundsaldo
    /// </summary
    public class Mynt {
	private string        namn;
	private    int       valör;
	private  float    diameter;
	private string beskrivning;
	private string    material;

	public string        Namn { get {        return namn; }}
	public int          Valör { get {       return valör; }}
	public float     Diameter { get {    return diameter; }}
	public string    Material { get {    return material; }}
	public string Beskrivning { get { return beskrivning; }}
	public Mynt(string namn, int valör, float diameter, string beskrivning, string material) {
	    this.namn        = namn;
	    this.valör       = valör;
	    this.diameter    = diameter;
	    this.beskrivning = beskrivning;
	    this.material    = material;
	}
    }
    public class Sedel {
	private string              namn;
	private    int             valör;
	private string beskrivning_verso; // framsida
	private string beskrivning_recto; // baksida

	public string  Namn { get { return namn; }}
	public    int Valör { get { return valör; }}
	public string Verso { get { return beskrivning_verso; }}
	public string Recto { get { return beskrivning_recto; }}
	public Sedel( string namn, int valör, string beskrivning_verso, string beskrivning_recto) {
	    this.namn        = namn;
	    this.valör       = valör;
	    this.beskrivning_verso = beskrivning_verso;
	    this.beskrivning_recto = beskrivning_recto;
	}
    }

    public class AccepteradeBetalningsmedel {
	//                                   diameter(mm) namn     material
	//  1 kungen i profil, från vänster  19,5         1-krona  "koppar-pläterat stål"
	//  5 kungens namnchiffer           23,75         5-krona  "nordiskt guld"
	// 10 kungen i profil, från vänster  20,5         10-krona "nordiskt guld"
	List<Mynt> accepteradeMynt = new List<Mynt>();

	//   20   Astrid
	//   50   Evert
	//  100   Greta
	//  200   Ingmar
	//  500   Birgit Nilsson
	// 1000   Dag Hammarskjöld
	List<Sedel> accepteradeSedlar = new List<Sedel>();

	public AccepteradeBetalningsmedel() {
	    accepteradeMynt.Add(new Mynt(   "kungen",  1, 19.50F, "kungen i profil, från vänster", "koppar-pläterat stål, kopparfärgat"));  // från Oskar II: mynt med kungens profil
	    accepteradeMynt.Add(new Mynt(  "5-krona",  5, 23.75F, "kungens namnchiffer",           "nordiskt guld"));
	    accepteradeMynt.Add(new Mynt( "10-krona", 10, 20.50F, "kungen i profil, från vänster", "nordiskt guld"));

	    accepteradeSedlar.Add(new Sedel( "Astrid",   20, "Astrid Lindgren",  "Småland, Linnés egen blomma - Linnea"));
	    accepteradeSedlar.Add(new Sedel( "Evert",    50, "Evert Taube",      "Bohuslän, båt från hällristning"));
	    accepteradeSedlar.Add(new Sedel( "Greta",   100, "Greta Garbo",      "Stockholm, Gamla stanvy"));
	    accepteradeSedlar.Add(new Sedel( "Ingmar",  200, "Ingmar Bergman",   "Gotland, Gotlandsraukar"));
	    accepteradeSedlar.Add(new Sedel( "Birgit",  500, "Birgit Nilsson",   "Skåne, Öresundsbron"));
	    accepteradeSedlar.Add(new Sedel( "Dag",    1000, "Dag Hammarskjöld", "Laponia"));
	}

	public bool accepterasMyntet( string namn) {
	    bool resultat = false;
	    foreach (Mynt mynt in accepteradeMynt)
		if (namn==mynt.Namn) {
		    resultat=true;
		    break;
		}
	    return resultat;
	}
	public bool accepterasSedeln( string namn) {
	    bool resultat = false;
	    foreach (Sedel sedel in accepteradeSedlar)
		if ( namn == sedel.Namn ) {
		    resultat = true;
		    break;
		}
	    return resultat;
	}
	public string[] allaAccepteradeMynt() {
	    string[] allaMynt  = new string[accepteradeMynt.Count];
	    int    i=0;

	    foreach (Mynt mynt in accepteradeMynt)
		allaMynt[i++] = mynt.Namn;

	    return allaMynt;
	}
	public string[] allaAccepteradeSedlar() {
	    string[] allaSedlar = new string[accepteradeSedlar.Count];
	    int    i=0;

	    foreach (Sedel sedel in accepteradeSedlar)
		allaSedlar[i++] = sedel.Namn;

	    return allaSedlar;
	}

	/// <summary>
	/// hur mycket är sedeln/myntet värt ?
	/// </summary>
	public int Värde(string namn) {
	    bool hittad = false;  /// error
	    int  värde=0;

	    foreach (Mynt mynt in accepteradeMynt)
		if (namn==mynt.Namn) {
		    värde = mynt.Valör;
		    hittad=true;
		    break;
		}
	    if (!hittad)
		foreach (Sedel sedel in accepteradeSedlar)
		    if (namn==sedel.Namn) {
			värde = sedel.Valör;
			hittad=true;
			break;
		    }
	    if(!hittad)
		throw new ArgumentException( "ej accepterad valör");
	    return värde;
	}
    }
}
