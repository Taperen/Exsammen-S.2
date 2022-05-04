using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public int TestMethod()
        {
            string Execute(string AddNewBookQuery)
            {
                throw new NotImplementedException();
            }
            // Arrange
            int i = 1;
            int Brugeren1 = 1;
            int B = 2;
            bool A = true;
            bool B = false;
            

            // Act

            if (i != 1)
            {
                string AddNewBookQuery =
                        $"{Brugeren1 + i}";
                Execute(AddNewBookQuery);
                return A;
            }
            else if (i == 1)
            {
                string AddNewBookQuery =
                        $"{B + i}";
                Execute(AddNewBookQuery);
                return B;
            }
            else
            {
                return 0;
            }


            // Assert
            Assert.IsTrue(Brugeren1>B);


        }

    }
}
