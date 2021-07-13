using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Leksak : Produkt {
	public override int Pris {
	    get { return base.pris; }
	    set { base.pris = value; }
	}
    }
}
