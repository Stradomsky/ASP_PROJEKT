#PhoneBook
Mateusz Stradomski 13831

## Wymagania

Aby korzystać z aplikacji wymagany jest pakiet [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

## Opis projektu

### Rejestracja

Dowolony użytkownik ma dostęp do strony https://localhost:7171/Login/SignUp (zakładka "Sign Up") na której w formularzu zostawia dane: login, adres email i hasło.
Po wysłaniu formularza, jeśli wszystkie dane zostały podane poprawnie uzytkownik jest przenoszony do strony profilu użytkownika.

### Logowanie 

Dowolony użytkownik ma dostęp do strony https://localhost:7171/Login/SignIn (zakładka "Sign In") w której może się zalogować podając login i hasło.
Po wysłaniu formularza, jeśli wszystkie dane zostały podane poprawnie uzytkownik jest przenoszony do strony profilu użytkownika.

### Uzupełnianie profilu użytkownika

Użytkownik posiadający konto w serwisie może uzupełnić swoje dane na stronie https://localhost:7171/User/PersonalData (zakładka "Profile") klikając w przycisk "Edit personal info". Następuje automatyczne przekierowanie do strony https://localhost:7171/User/PersonalDataEdition w której należy dokonać zmian, a następnie je zatwierdzić klikając w przycisk "Edit", następuje autmatyczne przekierowanie do strony https://localhost:7171/User/PersonalData (zakładka "Profile").

### Zmiana hasła

Użytkownik może zmienić swoje dotychczasowe hasło na nowe na stronie https://localhost:7171/User/PersonalData (zakładka "Profile") klikając w przycisk "Change password". Następuje autmatyczne przekierowanie do strony https://localhost:7171/User/ChangePassword w której nalezy podać dotychczasowe hasło, nowe hasło oraz powtórzyć nowe hasło, następnie należy zatwierdzić zmiany klikając w przycisk "Change password", następuje automatyczne przekierowanie do strony https://localhost:7171/User/PersonalData (zakładka "Profile").

### Zmiana licencji użytkownika

Użytkownik "standardowy" może zmienić swoje prawa na prawa użytkownika "premium" ulepszając swoją licencję na stronie https://localhost:7171/User/PersonalData (zakładka "Profile") klikając w przycisk "Upgrade version". Następuje automatyczne przekierowanie do strony https://localhost:7171/User/UpgradeUser w której należy podać klucz aktywacyjny ('QWERTY123' lub 'ASDFG456') i zatwierdzić zmiany klikając w przycisk "Upgrade", licencja zostanie zmieniona na "premium" i nastąpi automatyczne przekierowanie do strony https://localhost:7171/User/PersonalData (zakładka "Profile").

### Dodawanie książek telefonicznych

Każdy zalogowany użytkownik może dodawać książki telefoniczne na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycisk "Add phonebook". Następuje automatczne przekierowanie do strony https://localhost:7171/PhoneBook/CreatePhoneBook, w której należy podać nazwę jaką chcemy, aby miała nowa książka telefoniczna, a następnie zatwierdzić formularz klikając w przycisk "Create", nowa książka telefoniczna zostanie utworzona i nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks").

### Usuwanie książek telefonicznych 

Każdy zalogowany użytkownik może usunąć istniejącą już książkę telefoniczną na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycik "Delete" przy nazwie książki, którą chcemy usunąć. Po usunięciu książki strona zostanie odświeżona. 

### Dodawanie kontaktów do książek telefonicznych

Każdy zalogowany użytkownik może dodawać kontakty do istniejącej książki telefonicznej na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycik "Show contacts" przy nazwie książki, do której chcemy dodać kontakt, nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowContacts?phoneBookId=[numer id książki telefonicznej do której dodajemy kontakt], a następnie klikając w przycisk "Add new contact", nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/CreateContact?phoneBookId=[numer id książki telefonicznej do której dodajemy kontakt] z formularzem, do którego należy wprowadzić nazwę kontaktu, numer telefonu i opis kontaktu. Aby przesłać formularz i utworzyć kontakt należy kliknąć w przycisk "Create", nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowContacts?phoneBookId=[numer id książki telefonicznej do której dodaliśmy nowy kontakt].

### Usuwanie kontaktów z książek telefonicznych

Każdy zalogowany użytkownik może usuwać kontakty z istniejącej książki telefonicznej na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycik "Show contacts" przy nazwie książki, z której chcemy usunąć kontakt, nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowContacts?phoneBookId=[numer id książki telefonicznej z której usuwamy kontakt], a następnie klikając w przycisk "Delete" przy kontakcie, usuwamy istniejący kontakt. Po usunięciu kontaktu strona zostanie odświeżona.

### Wylogowywanie

Aby wylogować się z serwisu, należy kliknąć w przycisk "Log out" umieszczony na górze każdej strony.
