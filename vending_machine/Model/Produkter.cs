using System;

namespace Varuautomat.Modell {
    public abstract class Produkt {
	protected int pris;

	public abstract int Pris {
	    get;
	    set;
	}
    }
}
