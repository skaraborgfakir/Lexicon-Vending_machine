using System;
using Varuautomat.Modell.Produkter;

namespace Varuautomat.Modell.Varulager {
    public class Varulager {
	Produkt[] varulager;

	public Varulager() {
	    this.varulager = new Produkt[0];
	}
    }
}
