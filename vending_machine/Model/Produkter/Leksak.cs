using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
    class Leksak : Produkt,ILeksak {
	public Leksak( string namn, int önskatPris) {
	    Namn = namn;
	    Pris = önskatPris;
	}
	public string Åldersrekommendation() {
	    return "lämpar sig för barn mellan 1-99 år";
	}
	public override string Examine() {
	    return "En leksak för alla åldrar";
	}
	public override string Use() {
	    return "En leksak för alla åldrar";
	}
    }
}
