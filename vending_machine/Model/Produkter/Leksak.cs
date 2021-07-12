using System;
using Varuautomat.Modell.Produkter;

namespace Varuautomat.Modell.Produkter {
    class Leksak : Produkt {
	public override int Pris {
	    get { return base.pris; }
	    set { base.pris = value; }
	}
    }
}
