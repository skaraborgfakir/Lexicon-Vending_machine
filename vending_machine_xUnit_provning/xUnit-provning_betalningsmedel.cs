using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Modell;

/// <summary> modulen ersätter Varuautomatkontrollanten.
/// AccepteradeBetalningsmedel har uppgifter och valör för de betalningsmedel som ska accepteras
/// Kontrollerar att betalningsmedel som ska vara ok, är det
/// Dessutom finns några prov av att ej tillåtna inte accepteras
/// </summary>
namespace Varuautomat.xUnit_provning {
    /// <summary> Testa att betalningsmedel som inte ska accepteras av klassen
    /// inte heller accepteras
    ///
    /// använder method i betalningsmedel för kontrollen och assert av dess resultat
    /// separata metoder för mynt och sedlar
    /// </summary>
    public class Felaktigt_Betalningsmedel1
    {
	/// mynt
	[Theory]
	[InlineData( "KungHaakon" )]
	[InlineData( "danskKrona" )]
	public void ProvaIckeAccepteradeMynt(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.False(resultat);
	}
	/// motsvarande för sedlar
	[Theory]
	[InlineData( "1Zdollar" )]
	[InlineData( "KopieradIngmar" )]
	[InlineData( "George Washington" )]
	public void ProvaIckeAccepteradSedel(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasSedeln(valör);
	    // Assert
	    Assert.False(resultat);
	}
    }

    /// <summary> Testa att betalningsmedel som inte ska accepteras av klassen inte heller accepteras
    ///
    /// testar att pengens namn inte finns i en sträng vektor
    /// separata metoder för mynt och sedlar
    /// </summary>
    public class Felaktigt_Betalningsmedel2
    {
	[Theory]
	[InlineData( "KungHaakon" )]
	[InlineData( "danskKrona" )]
	public void ProvaIckeAccepteradeMynt(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeMynt = accepteradeBetalningsmedel.allaAccepteradeMynt();
	    // Assert
	    Assert.DoesNotContain(valör,  allaAccepteradeMynt);
	}

	/// motsvarande för sedlar
	[Theory]
	[InlineData( "1 Zimbabwe dollar" )]
	[InlineData( "Kopierad Ingmar" )]
	[InlineData( "George Washington" )]
	public void ProvaIckeAccepteradSedel(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeSedlar = accepteradeBetalningsmedel.allaAccepteradeSedlar();
	    // Assert
	    Assert.DoesNotContain(valör,  allaAccepteradeSedlar);
	}
    }

    /// <summary> Testa att betalningsmedel som inte ska accepteras av klassen inte heller accepteras
    ///
    /// testar att vad som händer för felaktiga pengar när man frågar om deras värde
    /// </summary>
    public class Felaktigt_Betalningsmedel3
    {
	[Theory]
	[InlineData( "KungHaakon" )]
	[InlineData( "danskKrona" )]
	public void ProvaIckeAccepteradPeng(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    Action act = () => accepteradeBetalningsmedel.Värde(valör);
	    //Assert
	    ArgumentException e = Assert.Throws<ArgumentException>(act);
	}
    }

    ///<summary> Testa att några legala betalningsmedel kan accepteras av Varuautomatens
    /// modul betalningsmedel
    /// separata metoder för mynt och sedlar
    ///</summary>
    public class Accepterade_Betalningsmedel1
    {
	[Theory]
	[InlineData( "kungen" )]
	[InlineData( "5-krona" )]
	public void ProvaAttMyntAccepteras(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(valör);
	    // Assert
	    Assert.True(resultat);
	}
	[Theory]
	[InlineData( "Astrid" )]
	[InlineData( "Ingmar" )]
	public void ProvaAttSedelAccepteras(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    bool resultat = accepteradeBetalningsmedel.accepterasSedeln(valör);
	    // Assert
	    Assert.True(resultat);
	}
    }

    ///<summary> Testa att några legala betalningsmedel kan accepteras av Varuautomatens
    /// modul betalningsmedel
    /// använder medlemstest i  allaAccepteradeMynt() och allaAccepteradeSedlar()
    /// separata metoder för mynt och sedlar
    ///</summary>
    public class Accepterade_Betalningsmedel2
    {
	[Theory]
	[InlineData( "kungen" )]
	[InlineData( "5-krona" )]
	public void ProvaAttMyntAccepteras(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeMynt = accepteradeBetalningsmedel.allaAccepteradeMynt();
	    // Assert
	    Assert.Contains(valör,  allaAccepteradeMynt);
	}
	[Theory]
	[InlineData( "Astrid" )]
	[InlineData( "Ingmar" )]
	public void ProvaAttSedelAccepteras(string valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    string[] allaAccepteradeSedlar = accepteradeBetalningsmedel.allaAccepteradeSedlar();
	    // Assert
	    Assert.Contains(valör,  allaAccepteradeSedlar);
	}
	[Theory]
	[InlineData( "Astrid", 20  )]
	[InlineData( "Ingmar", 200 )]
	public void ProvaSedelsVärde(string namn, int valör) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    // Act
	    int värde = accepteradeBetalningsmedel.Värde(namn);
	    // Assert
	    Assert.True(valör==värde);
	}
    }

    /// <summary> Testa att några legala betalningsmedel kan accepteras av Varuautomatens
    /// modul betalningsmedel
    /// gemensan metod för mynt och sedlar och enumerator
    /// <summary>
    public class Accepterade_Betalningsmedel3 {
	[Theory]
	[ClassData(typeof(BlandadeValörerData))]
	public void BlandadeValörer(string[] blandadeValörer) {
	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    bool resultat = false;
	    // Act
	    foreach (string valör in blandadeValörer)
	    {
		if ((!resultat) &
		    ( accepteradeBetalningsmedel.accepterasMyntet(valör) ||
		      accepteradeBetalningsmedel.accepterasSedeln(valör)))
		    resultat = true;
	    }
	    // Assert
	    Assert.True(resultat);
	}
	public class BlandadeValörerData : IEnumerable<object[]> {
	    public IEnumerator<object[]> GetEnumerator() {
		yield return new object[] { new string[] { "5-krona", "Ingmar", "Astrid", "Astrid", "Astrid", "Astrid"}};
	    }
	    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
    }

    //
    // kontrollera att valörerna är sorterade i sjunkande ordning
    //
    public class KontrolleraOrdning {
	[Theory]
	[InlineData( "Ingmar" )]
	public void KontrolleraSorteringEfterValör( string namn1) {
	    // Arrange
	    _ = namn1;
	    bool resultat = true;

	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
	    string[] derasNamn = accepteradeBetalningsmedel.allaAccepteradeBetalningsmedel();
	    int tidgareVärde = accepteradeBetalningsmedel.Värde(derasNamn[0]);

	    // Act
	    foreach (string valör in derasNamn) {
		if (accepteradeBetalningsmedel.Värde(valör) > tidgareVärde) {
		    resultat = false;
		    break;
		}
		tidgareVärde = accepteradeBetalningsmedel.Värde(valör);
	    }

	    // Assert
	    Assert.True(resultat);
	}
    }

    public class DumpAccepterade_Betalningsmedel {
	[Theory]
	[InlineData( "Ingmar" )]
	public void Dump( string namn1) {
	    _ = namn1;

	    // Arrange
	    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();

	    string[] derasNamn = accepteradeBetalningsmedel.allaAccepteradeBetalningsmedel();
	    foreach (string namn in derasNamn) {
		Console.WriteLine( namn);
	    }
	}
    }
}
