using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;
using Varuautomat.Modell.Betalningsmedel;

/// <summary> modulen ersätter Varuautomatkontrollanten
/// </summary>
namespace Varuautomat.Betalningsmedel_xUnit_provning {
    /// <summary> Testa att endast legala betalningsmedel accepteras av Varuautomaten
    /// i samtliga fall förväntas att det blir en exception
    /// </summary>
    public class Felaktigt_Betalningsmedel
    {
	[Theory]
	[InlineData( "danskKrona" )]
	public void MyntprovDanskkrona(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}

	[Theory]
	[InlineData( "1Zdollar" )]
	public void MyntprovZimbabwedollar(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}

	[Theory]
	[InlineData( "KungHaakon" )]
	public void SedelprovNorskKrona(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}

	[Theory]
	[InlineData( "KopieradIngmar" )]
	public void SedelprovKopierad500(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}
    }

    ///<summary> Testa att några legala betalningsmedel accepteras av Varuautomaten
    ///</summary>
    public class Legalt_Betalningsmedel
    {
	[Theory]
	[InlineData( "1Krona" )]
	public void Myntprov1krona(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}
	[Theory]
	[InlineData( "namnChiffer" )]
	public void MyntprovNamnchiffer(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}
	[Theory]
	[InlineData( "Selma" )]
	public void SedelprovSelma(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}
	[Theory]
	[InlineData( "Ingmar" )]
	public void SedelprovIngmar(string valör) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();
	    // Act
	    varuAutomat.InsertMoney( valör);
	    // Assert
	}

	[Theory]
	[ClassData(typeof(BlandadeValörerData))]
	public void BlandadeValörer(int summa, string[] blandadeValörer) {
	    // Arrange
	    Modell.Varuautomat varuAutomat = new Modell.Varuautomat();

	    // Act
	    foreach ( string valörNamn in blandadeValörer) {
		varuAutomat.InsertMoney( valörNamn);
	    }

	    // Assert
	    Assert.Equal( summa, varuAutomat.KundSaldo);
	}
	public class BlandadeValörerData : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { 580, new string[] { "Ingmar", "Selma", "Selma", "Selma", "Selma"}};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }
}
