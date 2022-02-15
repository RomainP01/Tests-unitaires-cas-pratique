using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                     "THEN: lorsque je tombe sur la face 1" +
                     "WHEN: je gagne 200 CD")]
        public void Test_WithADiceValueEqualsToOne()
        {
            //Arrange
            Dice dice = new Dice();

            //Act & Assert 
            Assert.IsTrue(dice.Faces.Contains(dice.Roll()));
        }
    }
}