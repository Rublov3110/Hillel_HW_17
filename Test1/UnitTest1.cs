using Microsoft.VisualStudio.CodeCoverage;
using Moq;
using Hillel_HW_12;
using System.ComponentModel;

namespace Test1
{
    public class UnitTest1
    {
        [Fact]
        public void AddMyFamiliarToRepository_WithMoq_Success()
        {
            //Arrange
            var repository = new Mock<IMyFamiliarRegister>();
            MyFamiliar savedMyFamiliar = null;
            repository
            .Setup(x => x.AddMyFamiliar(It.IsAny<MyFamiliar>()))
                .Callback((MyFamiliar myFamiliar) => savedMyFamiliar = myFamiliar);

            var service = new MyFamiliarRegister(repository.Object);
            var myFamiliar = new MyFamiliar
            {
                Avatarka = "test",
                Name = "Slavik",
                Surname = "Rublov",
                Status = new List<Status>
                {
                    new Status { MyFamiliatStatus = "Femely" }
                },
                Age = 28,
                Number = 8054125469,
                Sity = "Harkiv",
                Description = "test"
            };

            //Act
            service.AddShip(myFamiliar);

            //Assert
            repository.Verify(
                familiarRepository => familiarRepository.AddMyFamiliar(It.IsAny<MyFamiliar>()),
                Times.Once());
            Assert.Same(MyFamiliar, savedMyFamiliar);
        }

        [Fact]
        public void GetMyFamiliar_WithMoq_Success()
        {
            //Arrange
            var myFamiliar = new MyFamiliar
            {
                Avatarka = "test",
                Name = "Slavik",
                Surname = "Rublov",
                Status = new List<Status>
                {
                    new Status { MyFamiliatStatus = "Femely" }
                },
                Age = 28,
                Number = 8054125469,
                Sity = "Harkiv",
                Description = "test"
            };

            var repository = new Mock<IMyFamiliarRegister>();
            repository
                .Setup(x => x.GetMyFamiliar(It.IsAny<MyFamiliar>()))
                .Returns(new List<MyFamiliar?> { myFamiliar });

            var service = new MyFamiliarRegister(repository.Object);

            //Act
            var myFamiliars = service.GetMyFamiliar(myFamiliar);

            //Assert
            repository.Verify(
                familiarRepository => familiarRepository.GetMyFamiliar(It.IsAny<MyFamiliar>()),
                Times.Once());
            Assert.Single(myFamiliars);
            Assert.Same(myFamiliars.Single(), myFamiliar);
        }
    }
}