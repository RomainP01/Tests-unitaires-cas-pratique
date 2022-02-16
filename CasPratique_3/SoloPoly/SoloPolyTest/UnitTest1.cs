using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SoloPoly;

namespace SoloPolyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_De_Roll()
        {
            //Arrange
            Dice dice = new Dice();

            //Act & Assert 
            Assert.IsTrue(dice.Faces.Contains(dice.Roll()));
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un lancé de dés," +
                     "WHEN: lorsque je tombe sur la face 1" +
                     "THEN: je gagne 200 CD")]
        public void Test_WithADiceValueEqualsToOne_ReturnVoidAnd200CDAreAddedToPlayerCD()
        {
            //Arrange
            GameManager gameManager = new GameManager();
            Player player = new Player();

            //Act
            gameManager.RollConsequences(player, 1);
            //Assert 
            Assert.AreEqual(1200, player.CryptoDevise);
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un lancé de dés," +
                     "WHEN: lorsque je tombe sur la face 2" +
                     "THEN: je gagne 600 CD")]
        public void Test_WithADiceValueEqualsToTwo_ReturnVoidAnd600CDAreAddedToPlayerCD()
        {
            //Arrange
            GameManager gameManager = new GameManager();
            Player player = new Player();

            //Act
            gameManager.RollConsequences(player, 2);
            //Assert 
            Assert.AreEqual(1600, player.CryptoDevise);
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un lancé de dés," +
                     "WHEN: lorsque je tombe sur la face 3" +
                     "THEN: je perds 1000 CD")]
        public void Test_WithADiceValueEqualsToThree_ReturnVoidAnd1000CDAreSubstractedFromPlayerCD()
        {
            //Arrange
            GameManager gameManager = new GameManager();
            Player player = new Player();

            //Act
            gameManager.RollConsequences(player, 3);
            //Assert 
            Assert.AreEqual(0, player.CryptoDevise);
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un lancé de dés," +
                     "WHEN: lorsque je tombe sur la face 4" +
                     "THEN: je multiplie mes CD par deux")]
        public void Test_WithADiceValueEqualsToFour_ReturnVoidAndPlayerCDAreMultipliedByTwo()
        {
            //Arrange
            GameManager gameManager = new GameManager();
            Player player = new Player();

            //Act
            gameManager.RollConsequences(player, 4);
            //Assert 
            Assert.AreEqual(2000, player.CryptoDevise);
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un lancé de dés," +
                     "WHEN: lorsque je tombe sur la face 5" +
                     "THEN: rien ne se passe")]
        public void Test_WithADiceValueEqualsToSix_ReturnVoidAndNothingHappened()
        {
            //Arrange
            GameManager gameManager = new GameManager();
            Player player = new Player();

            //Act
            gameManager.RollConsequences(player, 6);
            //Assert 
            Assert.AreEqual(1000, player.CryptoDevise);
        }
        
        [TestMethod]
        [Description("GIVEN: Etant donné un lancé de dés," +
                     "WHEN: lorsque je ne tombe pas entre un chiffre compris entre 1 et 6" +
                     "THEN: une exception est levée")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_WithADiceValueEqualsToSix_ReturnException()
        {
            //Arrange
            GameManager gameManager = new GameManager();
            Player player = new Player();

            //Act & Assert
            gameManager.RollConsequences(player, 0);  
        }
        
    }
}