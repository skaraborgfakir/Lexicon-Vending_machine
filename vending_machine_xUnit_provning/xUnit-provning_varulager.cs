using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

/// <summary> modulen ersätter Varuautomatkontrollanten
/// kontrollera att några saker finns i varulager
/// </summary>
namespace Varuautomat.xUnit_provning {
    public class IckeExisterandeVaror {
	[Theory]
	[InlineData( "Superdestroyer Executor" )]
	[InlineData( "Starship Executor" )]
	[InlineData( "Dajm" )]
	[InlineData( "Lönnsirap" )]
	public void VadFinnsInteSomProdukt( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    string[] allaProdukter = varulager.AllaProduktersNamn();
	    // Assert
	    Assert.DoesNotContain( produktnamn, allaProdukter);
	}
    }

    public class ExisterandeVaror {
	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Japp" )]
	[InlineData( "Ångbåt" )]
	[InlineData( "Te" )]
	[InlineData( "Kaffe" )]
	[InlineData( "Coca Cola" )]
	public void VadFinnsILager1( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    string[] allaProdukter = varulager.AllaProduktersNamn();
	    // Assert
	    Assert.Contains( produktnamn, allaProdukter);
	}

	[Theory]
	[InlineData( "Starship Enterprise" )]
	[InlineData( "Japp" )]
	[InlineData( "Ångbåt" )]
	[InlineData( "Te" )]
	[InlineData( "Kaffe" )]
	[InlineData( "Coca Cola" )]
	public void VadFinnsILager2( string produktnamn) {
	    // Arrange
	    Modell.Varulager varulager = new Modell.Varulager();
	    // Act
	    bool resultat = varulager.finnsProdukten(produktnamn);
	    // Assert
	    Assert.True(resultat);
	}
    }
}
