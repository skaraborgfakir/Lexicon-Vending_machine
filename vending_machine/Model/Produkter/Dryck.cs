using System;
using Varuautomat.Modell.Produkter;

namespace Varuautomat.Modell.Produkter {
    class Dryck : Produkt, IAvseddAttÄtas {
	public override int Pris {
	    get { return base.pris; }
	    set { base.pris = value; }
	}

	public string NäringsInformation() {
	    return "svalkande, innehåll H2O";
	}
    }
}
