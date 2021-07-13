using System;
using System.Collections.Generic;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    public enum Produkttyper {
	dricka,
	lego,
	leksak,
	mellanmål,
	choklad
    }

    public class Varulager {
	// Produkt[] varulager;
	Dictionary<Produkt, int> varulager;

	public Varulager() {
	    /// this.varulager = new Produkt[0];
	    varulager = new Dictionary<Produkt, int>();

	    this.varulager.Add( new Dryck("Coca Cola", 12), 20);
	    this.varulager.Add( new Dryck("Te", 8), 120);
	    this.varulager.Add( new Dryck("Kaffe", 8), 120);
	    this.varulager.Add( new Dryck("Champis", 12), 20);

	    this.varulager.Add( new Lego("Ångbåt", 500), 4);
	    this.varulager.Add( new Lego("Starship Enterprise", 2000), 2);
	    this.varulager.Add( new Lego("Polisstation", 400), 10);

	    this.varulager.Add( new Leksak("Märklin startsats HO", 4000), 1);

	    this.varulager.Add( new Choklad("Japp",    20), 50);
	    this.varulager.Add( new Choklad("Marabou", 20), 50);
	    this.varulager.Add( new Choklad("Bilar",   20), 50);

	    this.varulager.Add( new Mellanmål("Renklämma",  10), 20);
	    this.varulager.Add( new Mellanmål("Knäckebröd", 30), 20);
	    this.varulager.Add( new Mellanmål("Äpple",      10), 20);
	}

	public string[] AllaProdukter() {
	    // foreach( KeyValuePair<string, string> kvp in openWith )
	    // {
	    //     Console.WriteLine("Key = {0}, Value = {1}",
	    //         kvp.Key, kvp.Value);
	    // }
	    string[] produkter = new string[varulager.Count];
	    int      i=0;

	    foreach ( KeyValuePair<Produkt,int> post in varulager)
		produkter[i++]=post.Key.Namn;

	    return produkter;
	}

	/// <summary>iterering över enbart en viss produkttyp
	/// </summary>
	public string[] AllaProdukter(Produkttyper söktTyp) {
	    string[] produkter = new string[0];
	    bool     träff=false;
	    string   namn="";

	    foreach ( KeyValuePair<Produkt,int> post in varulager) {
		switch(söktTyp) {
		    case Produkttyper.dricka:
			if (post.Key is Dryck) {
			    träff = true;
			    namn = post.Key.Namn;
			}
			break;
		    case Produkttyper.lego:
			if (post.Key is Lego) {
			    träff = true;
			    namn = post.Key.Namn;
			}
			break;
		    case Produkttyper.leksak:
			if (post.Key is Leksak) {
			    träff = true;
			    namn = post.Key.Namn;
			}
			break;
		    case Produkttyper.mellanmål:
			if (post.Key is Mellanmål) {
			    träff = true;
			    namn = post.Key.Namn;
			}

			break;
		    case Produkttyper.choklad:
			if (post.Key is Choklad) {
			    träff = true;
			    namn = post.Key.Namn;
			}
			break;
		}

		// else if (typ == Lego && (post.Key as Lego))
		//     träff = true;
		// else if (typ == Leksak && post.Key as Leksak)
		//     träff = true;
		// else if (typ == Mellanmål && post.Key as Mellanmål)
		//     träff = true;
		// else if (typ == Choklad && post.Key as Choklad)
		//     träff = true;

		if (träff) {
		    string[] förlängd=new string[produkter.Length+1];
		    Array.Copy(produkter, förlängd, produkter.Length);
		    förlängd[produkter.Length]=namn;
		    produkter=förlängd;
		    träff=false;
		}
	    }

	    return produkter;
	}
    }
}
