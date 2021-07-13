using System;
using Xunit;
using Varuautomat.Modell;

namespace Varuautomat.xUnit_provning {
    public class Varuautomatprovning
    {
	[Theory]
	[InlineData( "Te" )]
	[InlineData( "Kaffe" )]
	[InlineData( "Coca Cola" )]
	public void VadFinnsILager( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.ShowAll();
	    // Assert
	    Assert.Contains( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Starship Executor" )]
	[InlineData( "Dajm" )]
	[InlineData( "Lönnsirap" )]
	public void VadFinnsInteILager( string produktnamn) {
	    // Arrange
	    Modell.Varuautomat varuautomat = new Modell.Varuautomat();
	    // Act
	    string[] allaProdukter = varuautomat.ShowAll();
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}
    }
}
