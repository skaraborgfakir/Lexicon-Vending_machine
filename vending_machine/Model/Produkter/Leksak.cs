using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Leksak : Produkt {
	// public override int Pris {
	//     get { return base.pris; }
	//     set { base.pris = value; }
	// }

	// public string Namn() { get { return base.pris;}}
	// }

	public Leksak( string namn, int önskatPris) {
	    base.Namn = namn;
	    base.Pris = önskatPris;
	}

    }
}
