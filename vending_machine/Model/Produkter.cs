using System;

namespace Varuautomat.Modell {
    public abstract class Produkt {
	protected int pris;
	string        namn;

	public int Pris {
	    get { return pris; }
	    set { pris = value; }
	}
	public string Namn {
	    get { return namn;}
	    set { namn = value;}
	}
	public abstract string Examine();
	public abstract string Use();
    }
}
