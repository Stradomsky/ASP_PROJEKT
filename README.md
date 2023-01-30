#PhoneBook
Mateusz Stradomski 13831

## Wymagania

Aby korzystać z aplikacji wymagany jest pakiet [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

## Opis projektu

### Rejestracja

Dowolony użytkownik ma dostęp do strony https://localhost:7171/Login/SignUp (zakładka "Sign Up") na której w formularzu zostawia dane: login, adres email i hasło.
Po wysłaniu formularza, jeśli wszystkie dane zostały podane poprawnie uzytkownik jest przenoszony do strony profilu użytkownika.

![SignUp](https://user-images.githubusercontent.com/93879114/215572808-c9f54b50-bfed-47c0-b0fd-619ea3f6fb2d.png)

### Logowanie 

Dowolony użytkownik ma dostęp do strony https://localhost:7171/Login/SignIn (zakładka "Sign In") w której może się zalogować podając login i hasło.
Po wysłaniu formularza, jeśli wszystkie dane zostały podane poprawnie uzytkownik jest przenoszony do strony profilu użytkownika.

![SignIn](https://user-images.githubusercontent.com/93879114/215572807-fd73dda8-67fa-491e-b941-e44aba37b14b.png)

### Uzupełnianie profilu użytkownika

Użytkownik posiadający konto w serwisie może uzupełnić swoje dane na stronie https://localhost:7171/User/PersonalData (zakładka "Profile") klikając w przycisk "Edit personal info". Następuje automatyczne przekierowanie do strony https://localhost:7171/User/PersonalDataEdition w której należy dokonać zmian, a następnie je zatwierdzić klikając w przycisk "Edit", następuje autmatyczne przekierowanie do strony https://localhost:7171/User/PersonalData (zakładka "Profile").

![Profile1](https://user-images.githubusercontent.com/93879114/215572795-eb99acf2-9fa7-4301-8490-2441dc1b3e3c.png)

![ProfileEdition](https://user-images.githubusercontent.com/93879114/215572798-b144ad9f-c76f-45a7-a0fe-3f8f2b1fe629.png)

### Zmiana hasła

Użytkownik może zmienić swoje dotychczasowe hasło na nowe na stronie https://localhost:7171/User/PersonalData (zakładka "Profile") klikając w przycisk "Change password". Następuje autmatyczne przekierowanie do strony https://localhost:7171/User/ChangePassword w której nalezy podać dotychczasowe hasło, nowe hasło oraz powtórzyć nowe hasło, następnie należy zatwierdzić zmiany klikając w przycisk "Change password", następuje automatyczne przekierowanie do strony https://localhost:7171/User/PersonalData (zakładka "Profile").

![ProfilePassword](https://user-images.githubusercontent.com/93879114/215572801-9f22e515-0025-401d-9593-e27febd48d80.png)

### Zmiana licencji użytkownika

Użytkownik "standardowy" może zmienić swoje prawa na prawa użytkownika "premium" ulepszając swoją licencję na stronie https://localhost:7171/User/PersonalData (zakładka "Profile") klikając w przycisk "Upgrade version". Następuje automatyczne przekierowanie do strony https://localhost:7171/User/UpgradeUser w której należy podać klucz aktywacyjny ('QWERTY123' lub 'ASDFG456') i zatwierdzić zmiany klikając w przycisk "Upgrade", licencja zostanie zmieniona na "premium" i nastąpi automatyczne przekierowanie do strony https://localhost:7171/User/PersonalData (zakładka "Profile").

![ProfileUpgrade](https://user-images.githubusercontent.com/93879114/215572805-e219ff11-9324-4a84-a99a-047ce0ba407d.png)

### Dodawanie książek telefonicznych

Każdy zalogowany użytkownik może dodawać książki telefoniczne na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycisk "Add phonebook". Następuje automatczne przekierowanie do strony https://localhost:7171/PhoneBook/CreatePhoneBook, w której należy podać nazwę jaką chcemy, aby miała nowa książka telefoniczna, a następnie zatwierdzić formularz klikając w przycisk "Create", nowa książka telefoniczna zostanie utworzona i nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks").

![PhonebookCreate1](https://user-images.githubusercontent.com/93879114/215572789-daf85877-b155-490a-b352-d3e5dde18af3.png)

![PhonebookCreate2](https://user-images.githubusercontent.com/93879114/215572790-af7f6a95-6009-44c8-aef5-32b36e2f6504.png)

### Usuwanie książek telefonicznych 

Każdy zalogowany użytkownik może usunąć istniejącą już książkę telefoniczną na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycik "Delete" przy nazwie książki, którą chcemy usunąć. Po usunięciu książki strona zostanie odświeżona. 

![PhonebookDelete](https://user-images.githubusercontent.com/93879114/215572791-308ea56c-39b0-4234-b6ea-3da6b05904b5.png)

### Dodawanie kontaktów do książek telefonicznych

Każdy zalogowany użytkownik może dodawać kontakty do istniejącej książki telefonicznej na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycik "Show contacts" przy nazwie książki, do której chcemy dodać kontakt, nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowContacts?phoneBookId=[numer id książki telefonicznej do której dodajemy kontakt], a następnie klikając w przycisk "Add new contact", nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/CreateContact?phoneBookId=[numer id książki telefonicznej do której dodajemy kontakt] z formularzem, do którego należy wprowadzić nazwę kontaktu, numer telefonu i opis kontaktu. Aby przesłać formularz i utworzyć kontakt należy kliknąć w przycisk "Create", nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowContacts?phoneBookId=[numer id książki telefonicznej do której dodaliśmy nowy kontakt].

![ContactsCreate1](https://user-images.githubusercontent.com/93879114/215572782-bab5522e-b2ae-4d36-ad78-29d9f07500c7.png)

![ContactsCreate2](https://user-images.githubusercontent.com/93879114/215572785-c5b50734-2da1-4cc2-9b4f-0c5a7ed95026.png)

### Usuwanie kontaktów z książek telefonicznych

Każdy zalogowany użytkownik może usuwać kontakty z istniejącej książki telefonicznej na stronie https://localhost:7171/PhoneBook/ShowAllPhoneBooks (zakładka "Phonebooks") klikając w przycik "Show contacts" przy nazwie książki, z której chcemy usunąć kontakt, nastąpi automatyczne przekierowanie do strony https://localhost:7171/PhoneBook/ShowContacts?phoneBookId=[numer id książki telefonicznej z której usuwamy kontakt], a następnie klikając w przycisk "Delete" przy kontakcie, usuwamy istniejący kontakt. Po usunięciu kontaktu strona zostanie odświeżona.

![ContactsDelete](https://user-images.githubusercontent.com/93879114/215572787-a9e11211-b102-482d-b18a-cc501382e4a4.png)

### Wylogowywanie

Aby wylogować się z serwisu, należy kliknąć w przycisk "Log out" umieszczony na górze każdej strony.
