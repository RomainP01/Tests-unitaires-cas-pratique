using System;
using ExamenGame;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ExamenGameTests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        [Description("GIVEN: Etant donné un combat, "+
                     "WHEN : lorsque le lancé du héros est inférieur à celui du monstre et que la météo est en mode soleil, "+
                     "THEN : alors le héros perd et ses pv sont réduits de la différence entre les deux dés ")]
        public void Test_WithMOQ_WithADiceValueLessThanTheSecondOne_SunMode_ReturnLostAndReduceHeroHPByTheDifferenceBetweenTheTwoDices()
        {
            //Arrange
            var meteo = Mock.Of<IFournisseurMeteo>();
            Mock.Get(meteo).Setup(m => m.QuelleEstLaMeteo()).Returns(Jeu.Meteo.Soleil);
            Jeu game = new Jeu(meteo);
            
            //Act
            var result = game.Tour(2, 4);
            
            //Assert 
            result.Should().Be(Resultat.Perdu, "Erreur lors du contrôle du résultat");
            game.Heros.Score.Should().Be(0, "Erreur dans le calcul des scores");
            game.Heros.PointDeVies.Should().Be(13);
            
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un combat, "+
                     "WHEN : lorsque le lancé du héros est inférieur à celui du monstre et que la météo est en mode pluie, "+
                     "THEN : alors le héros perd et ses pv sont réduits de la différence entre les deux dés ")]
        public void Test_WithMOQ_WithADiceValueLessThanTheSecondOne_RainMode_ReturnLostAndReduceHeroHPByTheDifferenceBetweenTheTwoDices()
        {
            //Arrange
            var meteo = Mock.Of<IFournisseurMeteo>();
            Mock.Get(meteo).Setup(m => m.QuelleEstLaMeteo()).Returns(Jeu.Meteo.Pluie);
            Jeu game = new Jeu(meteo);
            
            //Act
            var result = game.Tour(2, 4);
            
            //Assert 
            result.Should().Be(Resultat.Perdu, "Erreur lors du contrôle du résultat");
            game.Heros.Score.Should().Be(0, "Erreur dans le calcul des scores");
            game.Heros.PointDeVies.Should().Be(13);
            
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un combat, "+
                     "WHEN : lorsque le lancé du héros est inférieur à celui du monstre et que la météo est en mode tempête, "+
                     "THEN : alors le héros perd et ses pv sont réduits de 2x la différence entre les deux dés ")]
        public void Test_WithMOQ_WithADiceValueLessThanTheSecondOne_StormMode_ReturnLostAndReduceHeroHPBy2TimesTheDifferenceBetweenTheTwoDices()
        {
            //Arrange
            var meteo = Mock.Of<IFournisseurMeteo>();
            Mock.Get(meteo).Setup(m => m.QuelleEstLaMeteo()).Returns(Jeu.Meteo.Tempete);
            Jeu game = new Jeu(meteo);
            
            //Act
            var result = game.Tour(2, 4);
            
            //Assert 
            result.Should().Be(Resultat.Perdu, "Erreur lors du contrôle du résultat");
            game.Heros.Score.Should().Be(0, "Erreur dans le calcul des scores");
            game.Heros.PointDeVies.Should().Be(11);
            
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un combat, "+
                     "WHEN : lorsque le lancé du héros est supérieur à celui du monstre, "+
                     "THEN : alors le héros gagne et son score augmente de 1 ")]
        public void Test_WithADiceValueMoreThanTheSecondOne_ReturnWinAndIncrementHeroScoreBy1()
        {
            //Arrange
            FournisseurMeteo meteo = new FournisseurMeteo();
            Jeu game = new Jeu(meteo);
            
            //Act
            var result = game.Tour(6, 4);
            
            //Assert 
            result.Should().Be(Resultat.Gagne, "Erreur lors du contrôle du résultat");
            game.Heros.Score.Should().Be(1, "Erreur dans le calcul des scores");
            
        }
        
        [TestMethod]
        public void Test_QuelleEstLaMétéo()
        {
            //Arrange
            FournisseurMeteo meteo = new FournisseurMeteo();

            //Assert 
            meteo.QuelleEstLaMeteo().Should().BeOneOf(Jeu.Meteo.Pluie, Jeu.Meteo.Soleil, Jeu.Meteo.Tempete);

        }
    }
}
