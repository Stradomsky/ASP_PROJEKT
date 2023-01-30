using Moq;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using PhoneBookApp.Logic.Services.PhoneBooks;
using Xunit;

namespace PhoneBookAoo.Tests.Services.PhoneBooks
{
    public class PhoneBookService_Tests
    {
        // Sut - serive under test czyli coś co chcemy w danej metodzie testować
        [Fact]
        public void GetAllPhoneBooks_ShouldReturn_CorrectPhoneBooks()
        {
            // ARRANGE
            List<PhoneBook> expectedPhoneBooks = new List<PhoneBook>
            {
                new PhoneBook { Name = "Testowa1", MaxSize = 10 },
                new PhoneBook { Name = "Testowa2", MaxSize = 10 },
                new PhoneBook { Name = "Testowa3", MaxSize = 10 }
            };

            User user = new User();

            Mock<IRepository<PhoneBook>> phoneBookRepositoryMock = new Mock<IRepository<PhoneBook>>();
            phoneBookRepositoryMock.Setup(x => x.GetAll()).Returns(expectedPhoneBooks);

            PhoneBookService sut = new PhoneBookService(phoneBookRepositoryMock.Object, null);

            // ACT
            List<PhoneBook> checkingPhoneBooks = sut.GetAllPhoneBooks(user);

            // ASSERTION
            Assert.Equal(checkingPhoneBooks, expectedPhoneBooks);
        }

        [Fact]
        public void GetPhoneBookById_ShouldReturn_CorrectPhoneBook()
        {
            // ARRANGE
            PhoneBook expectedPhoneBook = new PhoneBook { Id = 1, Name = "Testowa1", MaxSize = 10 };

            List<PhoneBook> expectedPhoneBooks = new List<PhoneBook>
            {
                expectedPhoneBook,
                new PhoneBook { Id = 2, Name = "Testowa2", MaxSize = 10 },
                new PhoneBook { Id = 3, Name = "Testowa3", MaxSize = 10 }
            };

            Mock<IRepository<PhoneBook>> phoneBookRepositoryMock = new Mock<IRepository<PhoneBook>>();
            phoneBookRepositoryMock.Setup(x => x.GetAll()).Returns(expectedPhoneBooks);

            PhoneBookService sut = new PhoneBookService(phoneBookRepositoryMock.Object, null);

            // ACT
            PhoneBook checkingPhoneBook = sut.GetPhoneBookById(1);

            // ASSERTION
            Assert.Equal(checkingPhoneBook, expectedPhoneBook);
        }

        [Fact]
        public void CreatePhoneBook_ShouldCreate_PhoneBook()
        {
            // ARRANGE
            User user = new User();
            PhoneBook expectedPhoneBook = new PhoneBook();

            Mock<IRepository<PhoneBook>> phoneBookRepositoryMock = new Mock<IRepository<PhoneBook>>();
            phoneBookRepositoryMock.Setup(x => x.SaveChanges());

            PhoneBookService sut = new PhoneBookService(phoneBookRepositoryMock.Object, null);

            // ACT
            sut.CreatePhoneBook(user, expectedPhoneBook);

            // ASSERTION
            bool userContainsExpectedPhoneBook = user.PhoneBooks.Contains(expectedPhoneBook);

            // Sposób na sprawdzenie, czy jakaś metoda z obiektów zależnych była wywołana
            phoneBookRepositoryMock.Verify(x => x.SaveChanges(), Times.Once());

            Assert.True(userContainsExpectedPhoneBook);
        }
    }
}
