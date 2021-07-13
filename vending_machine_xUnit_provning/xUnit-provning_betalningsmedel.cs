using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

/// <summary> modulen ersätter Varuautomatkontrollanten
/// kontrollera att betalningsmedel som ska vara ok, är det
/// dessutom finns några prov av att ej tillåtna inte accepteras
/// </summary>
namespace Varuautomat.xUnit_provning {
    /// <summary> Testa att endast legala betalningsmedel accepteras av Varuautomaten
    /// i samtliga fall förväntas att det blir en exception.
    /// använder method i betalningsmedel för kontrollen
    /// </summary>
    public class Felaktigt_Betalningsmedel1
    {
	[Theory]
	[InlineData( "danskKrona" )]
	public void MyntprovDanskkrona(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.False(resultat);
	}

	[Theory]
	[InlineData( "1Zdollar" )]
	public void MyntprovZimbabwedollar(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.False(resultat);
	}

	[Theory]
	[InlineData( "KungHaakon" )]
	public void SedelprovNorskKrona(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.False(resultat);
	}

	[Theory]
	[InlineData( "KopieradIngmar" )]
	public void SedelprovKopierad500(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasSedeln(valör);
	    // Assert
	    Assert.False(resultat);
	}
    }
    /// <summary> Testa att endast legala betalningsmedel accepteras av Varuautomaten
    /// i samtliga fall förväntas att det blir en exception.
    /// använder medlemstest i  allaAccepteradeMynt() och allaAccepteradeSedlar()
    /// </summary>
    public class Felaktigt_Betalningsmedel2
    {
	[Theory]
	[InlineData( "danskKrona" )]
	public void MyntprovDanskkrona(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeMynt = accepteradeBetalningsmedel.allaAccepteradeMynt();
	    // Assert
	    Assert.DoesNotContain(valör,  allaAccepteradeMynt);
	}

	[Theory]
	[InlineData( "1Zdollar" )]
	public void MyntprovZimbabwedollar(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeMynt = accepteradeBetalningsmedel.allaAccepteradeMynt();
	    // Assert
	    Assert.DoesNotContain(valör,  allaAccepteradeMynt);
	}

	[Theory]
	[InlineData( "KungHaakon" )]
	public void SedelprovNorskKrona(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeMynt = accepteradeBetalningsmedel.allaAccepteradeMynt();
	    // Assert
	    Assert.DoesNotContain(valör,  allaAccepteradeMynt);
	}

	[Theory]
	[InlineData( "KopieradIngmar" )]
	public void SedelprovKopierad500(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeSedlar = accepteradeBetalningsmedel.allaAccepteradeSedlar();
	    // Assert
	    Assert.DoesNotContain(valör,  allaAccepteradeSedlar);
	}
    }

    ///<summary> Testa att några legala betalningsmedel accepteras av Varuautomaten
    ///</summary>
    public class Accepterade_Betalningsmedel1
    {
	[Theory]
	[InlineData( "kungen" )]
	public void Myntprov1krona(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.True(resultat);
	}
	[Theory]
	[InlineData( "5-krona" )]
	public void MyntprovNamnchiffer(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.True(resultat);
	}
	[Theory]
	[InlineData( "Astrid" )]
	public void SedelprovSelma(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasSedeln(valör);
	    // Assert
	    Assert.True(resultat);
	}
	[Theory]
	[InlineData( "Ingmar" )]
	public void SedelprovIngmar(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasSedeln(valör);
	    // Assert
	    Assert.True(resultat);
	}

	[Theory]
	[ClassData(typeof(BlandadeValörerData))]
	public void BlandadeValörer(string[] blandadeValörer) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    bool resultat = true;
	    // Act
	    foreach (string valör in blandadeValörer)
		if ( !accepteradeBetalningsmedel.accepterasMyntet(valör) &&
		     !accepteradeBetalningsmedel.accepterasSedeln(valör))
		    resultat = false;
	    // Assert
	    Assert.True(resultat);
	}
	public class BlandadeValörerData : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { new string[] { "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }
    ///<summary> Testa att några legala betalningsmedel accepteras av Varuautomaten
    /// använder medlemstest i  allaAccepteradeMynt() och allaAccepteradeSedlar()
    ///</summary>
    public class Accepterade_Betalningsmedel2
    {
	[Theory]
	[InlineData( "kungen" )]
	public void Myntprov1krona(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeMynt = accepteradeBetalningsmedel.allaAccepteradeMynt();
	    // Assert
	    Assert.Contains(valör,  allaAccepteradeMynt);
	}
    }
}
