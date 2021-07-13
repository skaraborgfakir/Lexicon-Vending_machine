using System;
using Varuautomat.Modell;

namespace Varuautomat.Modell {
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
